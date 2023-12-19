using System;
using System.Windows.Forms;
using Msg = NativeMethods.Msg;


public class DialogNativeWindow : NativeWindow, IDisposable
{
    IntPtr handle; //待扩展对话框控件的句柄
    Control customControl;
    ChildControlNativeWindow childNative = null;
    public Action<IntPtr, Control> setControlLocationDlg=null;
    public Action<IntPtr, IntPtr> setChildControlDlg=null;

    public DialogNativeWindow(IntPtr handle, Control ctrl)
    {
        this.handle = handle;
        this.customControl = ctrl;
        AssignHandle(handle);
    }


    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case (int)Msg.WM_SHOWWINDOW: //窗体显示
                {
                    AddControl();
                    NativeChild();
                    UpdateLocation(m);
                    break;
                }
            case (int)Msg.WM_EXITSIZEMOVE:
            case (int)Msg.WM_SIZING:
            case (int)Msg.WM_SIZE:
                UpdateLocation(m);
                break;
        }

        base.WndProc(ref m);
    }

    private void AddControl()
    {
        if (customControl == null)
        {
            return;
        }
        NativeMethods.SetParent(customControl.Handle, handle);
    }

    private void NativeChild()
    {
        //查找对话框中的子控件
        NativeMethods.EnumChildWindows(handle, new NativeMethods.EnumWindowsCallBack(WindowCallBack), 0);
    }

    private bool WindowCallBack(IntPtr childHandle, int lparam)
    {
        if (setChildControlDlg != null)
        {
            setChildControlDlg.Invoke(this.handle, childHandle);
        }
        return true;
    }
    private void UpdateLocation(Message m)
    {
        if (customControl!=null)
        {
            customControl.Invalidate();
        }
        if (setControlLocationDlg != null && customControl!=null)
        {
            setControlLocationDlg.Invoke(handle, customControl);
        }
    }

    public void Dispose()
    {
        ReleaseHandle(); //释放与扩展对话框的句柄关联
        if (childNative != null)
        {
            childNative.Dispose();
        }
    }
}

