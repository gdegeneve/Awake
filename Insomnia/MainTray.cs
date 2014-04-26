using Insomnia.Properties;
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

namespace Insomnia
{
    public partial class MainTray : Form
    {
        private uint _prevExecutionState;

        private RegistryKey _regpath = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private RegistryKey _regsettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\" + Application.ProductName + "\\" + Application.ProductVersion);

        int idletime = 0;

        public MainTray()
        {
            InitializeComponent();
            if (_regpath.GetValue("Insomnia") == null)
            {
                startWithWindowsToolStripMenuItem.Checked = false;
            }
            else
            {
                startWithWindowsToolStripMenuItem.Checked = true;
            }
            GetStatus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void mi_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainTray_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            this.notico_tray.ShowBalloonTip(3000, "Insomnia", "Right click to configure", ToolTipIcon.Info);

        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startWithWindowsToolStripMenuItem.Checked)
            {
                _regpath.SetValue("Insomnia", Application.ExecutablePath.ToString());
            }
            else
            {
                _regpath.DeleteValue("Insomnia", false);
            }
        }


        private void continousTick_Tick(object sender, EventArgs e)
        {
            SetStatus(false);
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearChecked();
            ToolStripMenuItem source = sender as ToolStripMenuItem;
            source.Checked = true;
            SetStatus(true);
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

            idletime = (IdleTicks / 1000 / 60) + 1;
        }

        private void SetStatus(bool commit)
        {
            SetIdleTime();

            if (foreverToolStripMenuItem.Checked)
            {
                _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);

                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Open;
                    _regsettings.SetValue("Period", -1, RegistryValueKind.DWord);
                }
            }
            else if (minutes15ToolStripMenuItem.Checked)
            {
                if (idletime < 15)
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
                }
                else
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
                }
                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    _regsettings.SetValue("Period", 15, RegistryValueKind.DWord);
                }
            }
            else if (minutes30ToolStripMenuItem.Checked)
            {
                if (idletime < 30)
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
                }
                else
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
                }
                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    _regsettings.SetValue("Period", 30, RegistryValueKind.DWord);
                }
            }
            else if (minutes45ToolStripMenuItem.Checked)
            {
                if (idletime < 45)
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
                }
                else
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
                }
                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    _regsettings.SetValue("Period", 45, RegistryValueKind.DWord);
                }
            }
            else if (hour1ToolStripMenuItem.Checked)
            {
                if (idletime < 60)
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
                }
                else
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
                }
                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    _regsettings.SetValue("Period", 60, RegistryValueKind.DWord);
                }
            }
            else if (hours2ToolStripMenuItem.Checked)
            {
                if (idletime < 120)
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS | Win32Wrapper.ES_DISPLAY_REQUIRED | Win32Wrapper.ES_SYSTEM_REQUIRED);
                }
                else
                {
                    _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);
                }
                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    _regsettings.SetValue("Period", 120, RegistryValueKind.DWord);
                }
            }
            else if (disabledToolStripMenuItem.Checked)
            {
                _prevExecutionState = Win32Wrapper.SetThreadExecutionState(Win32Wrapper.ES_CONTINUOUS);

                if (commit)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleep;
                    _regsettings.SetValue("Period", 0, RegistryValueKind.DWord);
                }
            }
        }

        private void GetStatus()
        {
            try
            {
                ClearChecked();
                int period = (int)_regsettings.GetValue("Period", -1);
                if (period == -1)
                {
                    notico_tray.Icon = Resources.CrazyEye_Open;
                    foreverToolStripMenuItem.Checked = true;
                }
                else if (period == 15)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    minutes15ToolStripMenuItem.Checked = true;
                }
                else if (period == 30)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    minutes30ToolStripMenuItem.Checked = true;
                }
                else if (period == 45)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    minutes45ToolStripMenuItem.Checked = true;
                }
                else if (period == 60)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    hour1ToolStripMenuItem.Checked = true;
                }
                else if (period == 120)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleepy;
                    hours2ToolStripMenuItem.Checked = true;
                }
                else if (period == 0)
                {
                    notico_tray.Icon = Resources.CrazyEye_Sleep;
                    disabledToolStripMenuItem.Checked = true;
                }
            }
            catch
            {
                ClearChecked();
                notico_tray.Icon = Resources.CrazyEye_Open;
                foreverToolStripMenuItem.Checked = true;
            }
        }

        private void ClearChecked()
        {
            minutes15ToolStripMenuItem.Checked = false;
            minutes30ToolStripMenuItem.Checked = false;
            minutes45ToolStripMenuItem.Checked = false;
            hour1ToolStripMenuItem.Checked = false;
            hours2ToolStripMenuItem.Checked = false;
            foreverToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = false;
        }

        private void httpinsomniacodeplexcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://insomnia.codeplex.com");
        }


    }
}
