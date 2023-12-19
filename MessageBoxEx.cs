using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinNotepad
{
    class MessageBoxEx
    {
        //测试样例
        internal static void test()
        {
            Show("提示消息", "提示标题", MessageBoxButtons.YesNoCancel, new string[] { "按钮一(&O)", "按钮二(&T)", "按钮三(&H)" });
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, string[] buttonTitles)
        {
            DummyForm frm = new DummyForm(buttons, buttonTitles);
            frm.Show();
            frm.WatchForActivate = true;
            DialogResult result = MessageBox.Show(frm, text, caption, buttons);
            frm.Close();
            return result;
        }

        class DummyForm : Form
        {
            IntPtr _handle;
            //MessageBoxButtons _buttons;
            string[] _buttonTitles = null;

            bool _watchForActivate = false;

            public bool WatchForActivate
            {
                get { return _watchForActivate; }
                set { _watchForActivate = value; }
            }

            public DummyForm(MessageBoxButtons buttons, string[] buttonTitles)
            {
                //_buttons = buttons;
                _buttonTitles = buttonTitles;

                //让自己在界面上看不到
                this.Text = "";
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(-32000, -32000);
                this.ShowInTaskbar = false;
            }

            protected override void OnShown(EventArgs e)
            {
                base.OnShown(e);
                //把自己藏起来，在任务列表里也看不到
                NativeMethods.SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 0, 0, 659);
            }

            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                if (_watchForActivate && m.Msg == 0x0006)
                {
                    _watchForActivate = false;
                    _handle = m.LParam;
                    CheckMsgbox();
                }
                base.WndProc(ref m);
            }

            private void CheckMsgbox()
            {
                if (_buttonTitles == null || _buttonTitles.Length == 0)
                    return;

                //按钮标题的索引
                int buttonTitleIndex = 0;
                //获取子控件的句柄
                IntPtr h = NativeMethods.GetWindow(_handle, (long)NativeMethods.GW.GW_CHILD);
                while (h != IntPtr.Zero)
                {
                    //按顺序把按钮标题赋上
                    if (NativeMethods.GetWindowClassName(h).Equals("Button"))
                    {
                        if (_buttonTitles.Length > buttonTitleIndex)
                        {
                            NativeMethods.SetWindowText(h, _buttonTitles[buttonTitleIndex]);
                            buttonTitleIndex++;
                        }
                    }
                    h = NativeMethods.GetWindow(h, (long)NativeMethods.GW.GW_HWNDNEXT);
                }
            }
        }
    }
}
