using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace WinNotepad
{
    public partial class ComboBoxWithLabel : UserControl
    {
        public ComboBoxWithLabel()
        {
            InitializeComponent();
        }
        private string labelName = string.Empty;

        private string[] comboBoxItems = { };

        private int comboBoxWidth = 100;

        [Category("自定义属性"), Description("文本描述")]
        public string LabelName
        {
            get
            {
                return labelName;
            }

            set
            {
                labelName = value;
                lblCboName.Text = labelName;
            }
        }

        [Category("自定义属性"), Description("下拉列表项")]
        public string[] ComboBoxItems
        {
            get
            {
                return comboBoxItems;
            }

            set
            {
                comboBoxItems = value;
                cboList.Items.Clear();
                cboList.Items.AddRange(comboBoxItems);
                if (cboList.Items.Count > 0)
                {
                    cboList.SelectedIndex = 0;
                }
            }
        }

        [Category("自定义属性"), Description("下拉列表宽度")]
        public int ComboBoxWidth
        {
            get
            {
                return comboBoxWidth;
            }

            set
            {
                comboBoxWidth = value;
                if (comboBoxWidth > 0)
                {
                    cboList.Width = comboBoxWidth;
                }
            }
        }

        public ComboBox InnerComboBox
        {
            get
            {
                return cboList;
            }
        }

        private void basePanel_SizeChanged(object sender, EventArgs e)
        {
            this.Width = basePanel.Width;
        }
    }
}
