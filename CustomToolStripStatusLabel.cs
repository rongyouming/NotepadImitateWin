using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotepad
{
    public partial class CustomToolStripStatusLabel : ToolStripStatusLabel
    {

        private int maxWidth=50;

        [Category("自定义属性"), Description("最大宽度")]
        public int MaxWidth
        {
            get
            {
                return maxWidth;
            }
            set
            {
                maxWidth = value;
                if (maxWidth >= 0)
                {
                    Invalidate();
                }
            }
        }

        public CustomToolStripStatusLabel()
        {
            InitializeComponent();
        }
    }
}
