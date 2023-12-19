using System;
using System.Windows.Forms;
public class MultiOpenFileDialog:MultiOpenDialogBase<OpenFileDialog>
{
    public bool Multiselect=false;
    public string Title = string.Empty;
    public string Filter = string.Empty;
    public string FileName = string.Empty;
    
    public override void SetDialogProp(CommonDialog instance)
    {
        OpenFileDialog open = (OpenFileDialog)instance;
        open.Multiselect = Multiselect;
        open.Title = (Title == string.Empty) ? open.Title : Title;
        open.Filter = (Filter == string.Empty) ? open.Filter : Filter;
        base.SetDialogProp(instance);
    }

    public override void WhenDialogResultOk(CommonDialog instance)
    {
        OpenFileDialog open = (OpenFileDialog)instance;
        open.Multiselect = Multiselect;
        FileName = open.FileName;
        base.WhenDialogResultOk(instance);
    }
}




