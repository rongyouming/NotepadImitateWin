using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Msg = NativeMethods.Msg;

public class MedianForm : Form
{
    DialogNativeWindow dialognative=null;
    Control customControl;
    public Action<IntPtr, Control> setControlLocationDlg = null;
    public Action<IntPtr, IntPtr> setChildControlDlg = null;

    public MedianForm(Control ctrl)
    {
        this.customControl = ctrl;
        StartPosition = FormStartPosition.Manual;
        FormBorderStyle = FormBorderStyle.None;
        Height = 0;
        Width = 0;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (dialognative != null)
        {
            dialognative.Dispose(); //释放资源
        }
        base.OnClosing(e);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == (int)Msg.WM_ACTIVATE)
        {
            StringBuilder wndClass = new StringBuilder(256);
            NativeMethods.GetClassName(m.LParam, wndClass, wndClass.Capacity);//获取控件类名
            if (dialognative==null && wndClass.ToString().StartsWith("#32770"))
            {
                dialognative = new DialogNativeWindow(m.LParam, this.customControl); //m.LParam为要打开的窗口句柄，开始监听OpenFileDialog的Windows消息
                dialognative.setControlLocationDlg = setControlLocationDlg;
                dialognative.setChildControlDlg = setChildControlDlg;
            }

        }
        base.WndProc(ref m);
    }
}


