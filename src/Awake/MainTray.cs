using Awake.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Awake
{
    public partial class MainTray : Form
    {
        private int _idleTime = 0;
        private bool _IsAutoStart = false;
        private uint _prevExecutionState;
        private volatile bool _IsLock = false;
        private volatile bool _IsDarkOnLock = false;

        private RegistryKey _regPath = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private RegistryKey _regSettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + Application.ProductName + "\\" + Application.ProductVersion);

        private List<SleepState> _states = new List<SleepState>();

        public MainTray()
        {
            InitializeComponent();

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            
            _states.Add(new SleepState(3, this.minutes15ToolStripMenuItem, Resources.CrazyEye_Sleepy));
            _states.Add(new SleepState(30, this.minutes30ToolStripMenuItem, Resources.CrazyEye_Sleepy));
            _states.Add(new SleepState(45, this.minutes45ToolStripMenuItem, Resources.CrazyEye_Sleepy));
            _states.Add(new SleepState(60, this.hour1ToolStripMenuItem, Resources.CrazyEye_Sleepy));
            _states.Add(new SleepState(120, this.hours2ToolStripMenuItem, Resources.CrazyEye_Sleepy));
            _states.Add(new SleepState(0, this.disabledToolStripMenuItem, Resources.CrazyEye_Sleep));
            _states.Add(new SleepState(-1, this.foreverToolStripMenuItem, Resources.CrazyEye_Open));

            CleanUpRunConfig();

            LoadApplicationState();
        }

        private void CleanUpRunConfig()
        {
            try
            {
                //cleanup on update from insomnia.exe to awake.exe
                if (_regPath.GetValue("Insomnia") != null)
                {
                    string path = _regPath.GetValue("Insomnia", "").ToString();
                    if (!string.IsNullOrEmpty(path) && !File.Exists(path))
                    {
                        _regPath.DeleteValue("Insomnia", false);
                    }
                }
                //cleanup on executable move
                if (_regPath.GetValue("AwakeDonGeatschOS") != null)
                {
                    string path = _regPath.GetValue("AwakeDonGeatschOS", "").ToString();

                    if (path == Application.ExecutablePath.ToString())
                        _IsAutoStart = true;

                    if (!string.IsNullOrEmpty(path) && (!File.Exists(path) || path != Application.ExecutablePath.ToString()))
                    {
                        _regPath.DeleteValue("AwakeDonGeatschOS", false);
                    }
                }
            }
            catch
            {
            }
        }

        private void ClearChecked()
        {
            foreach (var item in _states)
            {
                item.MenuItem.Checked = false;
            }
        }

        private void LoadApplicationState()
        {
            try
            {
                if (_regPath.GetValue("AwakeDonGeatschOS") == null)
                {
                    startWithWindowsToolStripMenuItem.Checked = false;
                }
                else
                {
                    startWithWindowsToolStripMenuItem.Checked = true;
                }
            }
            catch
            {
                startWithWindowsToolStripMenuItem.Checked = false;
            }
            try
            {
                ClearChecked();
                int period = (int)_regSettings.GetValue("Period", -1);

                var state = _states.FirstOrDefault(s => s.Period == period);
                notico_tray.Icon = state.Icon;
                state.MenuItem.Checked = true;
            }
            catch
            {
                ClearChecked();
                notico_tray.Icon = Resources.CrazyEye_Open;
                foreverToolStripMenuItem.Checked = true;
            }

            try
            {
                disableOnLockScreenToolStripMenuItem.Checked = ((int)_regSettings.GetValue("DeactivateOnLock", 0)) == 0 ? false : true;
                monitorOffOnLockScreenToolStripMenuItem.Checked = ((int)_regSettings.GetValue("ForceBlackScreenOnLock", 0)) == 0 ? false : true;

            }
            catch
            {
            }
        }

        private void SaveApplicationState()
        {
            if (startWithWindowsToolStripMenuItem.Checked)
            {
                _regPath.SetValue("AwakeDonGeatschOS", Application.ExecutablePath.ToString());
            }
            else
            {
                _regPath.DeleteValue("AwakeDonGeatschOS", false);
            }

            var state = _states.FirstOrDefault(s => s.MenuItem.Checked);
            notico_tray.Icon = state.Icon;
            _regSettings.SetValue("Period", state.Period, RegistryValueKind.DWord);

            try
            {
                _regSettings.SetValue("DeactivateOnLock", disableOnLockScreenToolStripMenuItem.Checked ? 1 : 0, RegistryValueKind.DWord);
                _regSettings.SetValue("ForceBlackScreenOnLock", monitorOffOnLockScreenToolStripMenuItem.Checked ? 1 : 0, RegistryValueKind.DWord);
            }
            catch
            {
            }
        }

        private void SetIdleTime()
        {
            int systemUptime = Environment.TickCount;
            int LastInputTicks = 0;
            int IdleTicks = 0;
            Win32Wrapper.LASTINPUTINFO LastInputInfo = new Win32Wrapper.LASTINPUTINFO();
            LastInputInfo.cbSize = (uint)Marshal.SizeOf(LastInputInfo);
            LastInputInfo.dwTime = 0;

            if (Win32Wrapper.GetLastInputInfo(ref LastInputInfo))
            {
                LastInputTicks = (int)LastInputInfo.dwTime;
                IdleTicks = systemUptime - LastInputTicks;
            }

            _idleTime = (IdleTicks / 1000 / 60) + 1;
        }

        private void SetState()
        {
            SetIdleTime();

            var state = _states.FirstOrDefault(s => s.MenuItem.Checked);

            if ((state.Period != -1 && _idleTime > state.Period) || (_IsLock && (disableOnLockScreenToolStripMenuItem.Checked)))
            {
                _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
            }
            else
            {
                _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
            }

            if (_IsLock && monitorOffOnLockScreenToolStripMenuItem.Checked && !_IsDarkOnLock)
            {
                Win32Wrapper.SendMessage(this.Handle, Win32Wrapper.WM_SYSCOMMAND, (IntPtr)Win32Wrapper.SC_MONITORPOWER, (IntPtr)2);
                _IsDarkOnLock = true;
            }
        }

        #region Form Events

        private void continousTick_Tick(object sender, EventArgs e)
        {
            SetState();
        }

        private void httpawakecodeplexcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://awake.codeplex.com");
        }

        private void MainTray_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            if (!_IsAutoStart)
                this.notico_tray.ShowBalloonTip(3000, "Awake", "Right click to configure.", ToolTipIcon.Info);
        }

        private void mi_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveStateMenuItem_Click(object sender, EventArgs e)
        {
            SaveApplicationState();

        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearChecked();
            ToolStripMenuItem source = sender as ToolStripMenuItem;
            source.Checked = true;

            SaveApplicationState();
        }

        void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                _IsLock = true;
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                _IsLock = false;
            }
            _IsDarkOnLock = false;
        }

        #endregion Form Events
    }

}