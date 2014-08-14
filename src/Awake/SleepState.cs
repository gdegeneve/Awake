using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Awake
{
    public class SleepState
    {
        public Icon Icon { get; set; }

        public ToolStripMenuItem MenuItem { get; set; }

        public int Period { get; set; }

        public SleepState(int period, ToolStripMenuItem menuItem, Icon icon)
        {
            this.Period = period;
            this.MenuItem = menuItem;
            this.Icon = icon;
        }
    }
}
