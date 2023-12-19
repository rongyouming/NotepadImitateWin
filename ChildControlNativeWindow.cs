using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ChildControlNativeWindow : NativeWindow, IDisposable
{
    IntPtr handle; //需要被监听消息的子控件句柄
    public ChildControlNativeWindow(IntPtr handle)
    {
        this.handle = handle;
        AssignHandle(handle);
    }

    public void Dispose()
    {
        ReleaseHandle();
    }
}

