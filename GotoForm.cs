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
    public partial class GotoForm : Form
    {
        private Action<int> gotoLineCallBack;
        public GotoForm()
        {
            InitializeComponent();
        }

        private void GotoForm_Load(object sender, EventArgs e)
        {
            gotoLineCallBack = this.Tag as Action<int>;
            //让文本框只能输入数字 输入其他字符会有错误提示气泡弹出
            long style = NativeMethods.GetWindowLong(txtLineNum.Handle, -16);
            NativeMethods.SetWindowLong(txtLineNum.Handle, -16, style | 0x2000);
            
            object robj = Misc.GetRegisterValue("GotoLineNum");
            if (robj!=null)
            {
                txtLineNum.Text = ((int)robj).ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            int line;
            bool b= int.TryParse(txtLineNum.Text,out line);
            if (b)
            {
                if (line==0 || line > Misc.lineCount)
                {
                    MessageBox.Show("行数超过了总行数", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                gotoLineCallBack(line);
                Misc.SetRegisterKV<int>("GotoLineNum", line);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入行号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GotoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void GotoForm_Activated(object sender, EventArgs e)
        {
            btnGoto.Focus();
        }

        private void txtLineNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLineNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==0x0D)
            {
                btnGoto_Click(null, null);
            }
        }
    }
}
