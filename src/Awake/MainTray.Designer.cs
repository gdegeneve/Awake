namespace Awake
{
    partial class MainTray
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTray));
            this.notico_tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_traymenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preventSleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutes15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutes30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutes45ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hour1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hours2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foreverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.lockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableOnLockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorOffOnLockScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preventsSleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpawakecodeplexcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.continousTick = new System.Windows.Forms.Timer(this.components);
            this.cms_traymenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notico_tray
            // 
            this.notico_tray.ContextMenuStrip = this.cms_traymenu;
            this.notico_tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notico_tray.Icon")));
            this.notico_tray.Text = "Awake";
            this.notico_tray.Visible = true;
            // 
            // cms_traymenu
            // 
            this.cms_traymenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preventSleepToolStripMenuItem,
            this.toolStripMenuItem2,
            this.lockScreenToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mi_exit});
            this.cms_traymenu.Name = "trayMenu";
            this.cms_traymenu.Size = new System.Drawing.Size(177, 132);
            // 
            // preventSleepToolStripMenuItem
            // 
            this.preventSleepToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disabledToolStripMenuItem,
            this.minutes15ToolStripMenuItem,
            this.minutes30ToolStripMenuItem,
            this.minutes45ToolStripMenuItem,
            this.hour1ToolStripMenuItem,
            this.hours2ToolStripMenuItem,
            this.foreverToolStripMenuItem});
            this.preventSleepToolStripMenuItem.Name = "preventSleepToolStripMenuItem";
            this.preventSleepToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.preventSleepToolStripMenuItem.Text = "Prevent Sleep";
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.disabledToolStripMenuItem.Text = "Disable";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // minutes15ToolStripMenuItem
            // 
            this.minutes15ToolStripMenuItem.Name = "minutes15ToolStripMenuItem";
            this.minutes15ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.minutes15ToolStripMenuItem.Text = "15 Minutes";
            this.minutes15ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // minutes30ToolStripMenuItem
            // 
            this.minutes30ToolStripMenuItem.Name = "minutes30ToolStripMenuItem";
            this.minutes30ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.minutes30ToolStripMenuItem.Text = "30 Minutes";
            this.minutes30ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // minutes45ToolStripMenuItem
            // 
            this.minutes45ToolStripMenuItem.Name = "minutes45ToolStripMenuItem";
            this.minutes45ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.minutes45ToolStripMenuItem.Text = "45 Minutes";
            this.minutes45ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // hour1ToolStripMenuItem
            // 
            this.hour1ToolStripMenuItem.Name = "hour1ToolStripMenuItem";
            this.hour1ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.hour1ToolStripMenuItem.Text = "1 Hour";
            this.hour1ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // hours2ToolStripMenuItem
            // 
            this.hours2ToolStripMenuItem.Name = "hours2ToolStripMenuItem";
            this.hours2ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.hours2ToolStripMenuItem.Text = "2 Hours";
            this.hours2ToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // foreverToolStripMenuItem
            // 
            this.foreverToolStripMenuItem.Checked = true;
            this.foreverToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.foreverToolStripMenuItem.Name = "foreverToolStripMenuItem";
            this.foreverToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.foreverToolStripMenuItem.Text = "Forever";
            this.foreverToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // lockScreenToolStripMenuItem
            // 
            this.lockScreenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableOnLockScreenToolStripMenuItem,
            this.monitorOffOnLockScreenToolStripMenuItem});
            this.lockScreenToolStripMenuItem.Name = "lockScreenToolStripMenuItem";
            this.lockScreenToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lockScreenToolStripMenuItem.Text = "Lock Screen";
            // 
            // disableOnLockScreenToolStripMenuItem
            // 
            this.disableOnLockScreenToolStripMenuItem.CheckOnClick = true;
            this.disableOnLockScreenToolStripMenuItem.Name = "disableOnLockScreenToolStripMenuItem";
            this.disableOnLockScreenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.disableOnLockScreenToolStripMenuItem.Text = "Disable Awake";
            this.disableOnLockScreenToolStripMenuItem.Click += new System.EventHandler(this.saveStateMenuItem_Click);
            // 
            // monitorOffOnLockScreenToolStripMenuItem
            // 
            this.monitorOffOnLockScreenToolStripMenuItem.CheckOnClick = true;
            this.monitorOffOnLockScreenToolStripMenuItem.Name = "monitorOffOnLockScreenToolStripMenuItem";
            this.monitorOffOnLockScreenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.monitorOffOnLockScreenToolStripMenuItem.Text = "Turn off the display (once)";
            this.monitorOffOnLockScreenToolStripMenuItem.Click += new System.EventHandler(this.saveStateMenuItem_Click);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.CheckOnClick = true;
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.saveStateMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preventsSleepToolStripMenuItem,
            this.httpawakecodeplexcomToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // preventsSleepToolStripMenuItem
            // 
            this.preventsSleepToolStripMenuItem.Enabled = false;
            this.preventsSleepToolStripMenuItem.Name = "preventsSleepToolStripMenuItem";
            this.preventsSleepToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.preventsSleepToolStripMenuItem.Text = "Copyright (c) 2014 Gerald Degeneve";
            // 
            // httpawakecodeplexcomToolStripMenuItem
            // 
            this.httpawakecodeplexcomToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.httpawakecodeplexcomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.httpawakecodeplexcomToolStripMenuItem.Name = "httpawakecodeplexcomToolStripMenuItem";
            this.httpawakecodeplexcomToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.httpawakecodeplexcomToolStripMenuItem.Text = "awake.codeplex.com";
            this.httpawakecodeplexcomToolStripMenuItem.Click += new System.EventHandler(this.httpawakecodeplexcomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // mi_exit
            // 
            this.mi_exit.Name = "mi_exit";
            this.mi_exit.Size = new System.Drawing.Size(176, 22);
            this.mi_exit.Text = "Exit";
            this.mi_exit.Click += new System.EventHandler(this.mi_exit_Click);
            // 
            // continousTick
            // 
            this.continousTick.Enabled = true;
            this.continousTick.Interval = 10000;
            this.continousTick.Tick += new System.EventHandler(this.continousTick_Tick);
            // 
            // MainTray
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainTray";
            this.Load += new System.EventHandler(this.MainTray_Load);
            this.cms_traymenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.NotifyIcon notico_tray;
        private System.Windows.Forms.ContextMenuStrip cms_traymenu;
        private System.Windows.Forms.ToolStripMenuItem mi_exit;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.Timer continousTick;
        private System.Windows.Forms.ToolStripMenuItem preventSleepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutes15ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutes30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutes45ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hour1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hours2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foreverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preventsSleepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpawakecodeplexcomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem lockScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableOnLockScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorOffOnLockScreenToolStripMenuItem;
    }
}

