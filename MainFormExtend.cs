using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNotepad
{
    public partial class MainForm
    {
        private ComboBoxWithLabel cbowlDropDownEncoding;
        private ComboBoxWithLabel cbowlSaveEncoding;

        private void InitializeComponentExtend()
        {
            cbowlDropDownEncoding = new ComboBoxWithLabel();
            cbowlDropDownEncoding.LabelName = "编码(E):";
            cbowlDropDownEncoding.ComboBoxItems = new string[]{"自动检测","ANSI","Unicode","UTF-8"};
            cbowlDropDownEncoding.ComboBoxWidth = 130;

            cbowlSaveEncoding = new ComboBoxWithLabel();
            cbowlSaveEncoding.LabelName = "编码(E):";
            cbowlSaveEncoding.ComboBoxItems = new string[] {"ANSI", "Unicode", "UTF-8" };
            cbowlSaveEncoding.ComboBoxWidth = 130;
        }
    }
}
