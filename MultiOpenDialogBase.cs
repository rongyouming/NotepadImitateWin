using System;
using System.Windows.Forms;
using SetWindowPosFlags = NativeMethods.SetWindowPosFlags;

public class MultiOpenDialogBase<T> where T : CommonDialog, new()
{
    protected const SetWindowPosFlags UFLAGSHIDE =
       SetWindowPosFlags.SWP_NOACTIVATE |
       SetWindowPosFlags.SWP_NOOWNERZORDER |
       SetWindowPosFlags.SWP_NOMOVE |
       SetWindowPosFlags.SWP_NOSIZE |
       SetWindowPosFlags.SWP_HIDEWINDOW;

    public Action<IntPtr, Control> setControlLocationDlg = null;
    public Action<IntPtr, IntPtr> setChildControlDlg = null;
    public Action setResultOkDlg = null;

    public CommonDialog dialogInstance = null;

    public DialogResult ShowDialog() 
    {
        return ShowDialog(null, null);
    }

    public DialogResult ShowDialog(IWin32Window owner, Control ctrl)
    {
        using (T dia = new T())
        {
            dialogInstance = dia;
            MedianForm median = new MedianForm(ctrl);
            median.setControlLocationDlg = setControlLocationDlg;
            median.setChildControlDlg = setChildControlDlg;
            median.Show(owner);
            NativeMethods.SetWindowPos(median.Handle, IntPtr.Zero, 0, 0, 0, 0, UFLAGSHIDE); //隐藏中间窗体
            SetDialogProp(this.dialogInstance);
            DialogResult dialogresult = dia.ShowDialog(median);
            if (dialogresult == DialogResult.OK)
            {
                WhenDialogResultOk(this.dialogInstance);
            }
            else
            {
                WhenDialogResultFail(this.dialogInstance);
            }
            median.Close();
            return dialogresult;
        }
    }

    public virtual void SetDialogProp(CommonDialog instance)
    {

    }

    public virtual void WhenDialogResultOk(CommonDialog instance)
    {
        if (setResultOkDlg!=null)
        {
            setResultOkDlg.Invoke();
        }
    }

    public virtual void WhenDialogResultFail(CommonDialog instance)
    {

    }
}

