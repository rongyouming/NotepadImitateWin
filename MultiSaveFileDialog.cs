using System;
using System.Windows.Forms;

namespace WinNotepad
{
    public class MultiSaveFileDialog: MultiOpenDialogBase<SaveFileDialog>
    {
        public string Title = string.Empty;
        public string Filter = string.Empty;
        public string FileName = string.Empty;
        public bool AddExtension = false;

        public override void SetDialogProp(CommonDialog instance)
        {
            SaveFileDialog save = (SaveFileDialog)instance;
            save.Title = (Title == string.Empty) ? save.Title : Title;
            save.Filter = (Filter == string.Empty) ? save.Filter : Filter;
            save.AddExtension = AddExtension;
            base.SetDialogProp(instance);
        }

        public override void WhenDialogResultOk(CommonDialog instance)
        {
            SaveFileDialog save = (SaveFileDialog)instance;
            FileName = save.FileName;
            base.WhenDialogResultOk(instance);
        }
    }
}
