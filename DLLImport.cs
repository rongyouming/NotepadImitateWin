using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Versioning;

namespace WinNotepad
{
    enum UndoOrRedoType
    {
        UnKnow,
        Typing,
        Delete,
        DragDrop,
        Cut,
        Paste
    }

    enum UndoOrRedo
    {
        Undo,
        Redo
    }

    static class DLLImport
    {
        public static readonly int WM_SETREDRAW = 0x000B;
        public static readonly int WM_USER = 0x400;
        public static readonly int EM_GETSEL = 0x00B0;
        public static readonly int EM_LINEFROMCHAR = 0x00C9;
        public static readonly int EM_HIDESELECTION = WM_USER + 63;
        public static readonly int EM_GETUNDONAME = WM_USER + 86;
        public static readonly int EM_GETREDONAME = WM_USER + 87;
        public static readonly int EM_STOPGROUPTYPING = WM_USER + 88;
        public static readonly int EM_GETSCROLLPOS = WM_USER + 221;
        public static readonly int EM_SETSCROLLPOS = WM_USER + 222;
        public static readonly int GW_CHILD = 5;
        public static readonly int GW_HWNDNEXT = 2;

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            #if DEBUG
            public override string ToString()
            {
                return "{x=" + x + ", y=" + y + "}";
            }
            #endif
        }

        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, Int32 nBar);

        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedra);

        [DllImport("user32.dll")]
        public static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, long wCmd);
        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("user32.dll")]
        public static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwndLock, Int32 wMsg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwndLock, Int32 wMsg, ref int wParam, ref int lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwndLock, Int32 wMsg, Int32 wParam, ref Point pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, POINT lParam);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool GetCaretPos(out Point ppt);

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nlndex);

        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nlndex,long dwNewLong);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowEx(int DdwExStyle,string lpClassName,  string lpWindowName, int dwStyle,int x,int y,int nWidth,int nHeight,IntPtr hWndParent,IntPtr hMenu,IntPtr hInstance,IntPtr lpParam);

        public static readonly Int32 SB_VERT = 0x00000001;

        public static string GetWindowClassName(IntPtr handle)
        {
            StringBuilder sb = new StringBuilder(256);

            GetClassNameW(handle, sb, sb.Capacity); //得到窗口类名并保存在strClass中
            return sb.ToString();
        }
    }
}
