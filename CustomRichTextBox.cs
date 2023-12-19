using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotepad
{
    public partial class CustomRichTextBox : RichTextBox
    {
        public CustomRichTextBox()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            //拦截0x288号消息 RichTextBox在获得焦点之后就不会重新回到光标位置 原因未知
            if (m.Msg != 0x288)
            {
                //Console.WriteLine(m.Msg.ToString("X6"));
                base.WndProc(ref m);
            }
        }
    }
}
