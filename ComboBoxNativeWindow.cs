using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinNotepad;

public class ComboBoxNativeWindow:ChildControlNativeWindow
{
    public ComboBoxNativeWindow(IntPtr handle): base(handle)
    {
       
    }

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case (int)NativeMethods.Msg.WM_COMMAND:
                Misc.charsetIndex = NativeMethods.SendMessage(this.Handle, NativeMethods.CB_GETCURSEL, 0, 0);
                break;
        }
        base.WndProc(ref m);
    }
}

