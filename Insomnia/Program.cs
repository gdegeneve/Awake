using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;


namespace Insomnia
{
    public static class Program
    {
        [STAThread()]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainTray());
        }
    }
}
