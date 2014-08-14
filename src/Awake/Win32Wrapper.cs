using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Awake
{
    public class Win32Wrapper
    {
        public const uint ES_AWAYMODE_REQUIRED = 0x00000040;

        public const uint ES_CONTINUOUS = 0x80000000;

        public const uint ES_DISPLAY_REQUIRED = 0x00000002;

        public const uint ES_SYSTEM_REQUIRED = 0x00000001;

        public const uint ES_USER_PRESENT = 0x00000004;

        public const uint WM_SYSCOMMAND = 0x112;

        public const uint SC_MONITORPOWER = 0xF170;

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("kernel32.dll")]
        public static extern uint SetThreadExecutionState(uint esFlags);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);

        
        public struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
    }
}