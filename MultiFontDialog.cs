using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotepad
{
    public class MultiFontDialog:MultiOpenDialogBase<FontDialog>
    {
        public bool AllowScriptChange = true;
        public Font currFont = null;
        public override void SetDialogProp(CommonDialog instance)
        {
            FontDialog fontDia = (FontDialog)instance;
            fontDia.AllowScriptChange = this.AllowScriptChange;
            fontDia.Font = currFont;
            base.SetDialogProp(instance);
        }
        public override void WhenDialogResultOk(CommonDialog instance)
        {
            FontDialog fontDia = (FontDialog)instance;
            this.currFont = fontDia.Font;
            base.WhenDialogResultOk(instance);
        }
    }
}
