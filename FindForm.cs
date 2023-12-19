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
    public partial class FindForm : Form
    {
        private Action<string, RichTextBoxFinds, bool> findKeyWordCallBack;
        private bool isCancel = false;

        public FindForm()
        {
            InitializeComponent();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                findKeyWordCallBack = this.Tag as Action<string, RichTextBoxFinds, bool>;
            }
            //读取注册表保存的设置
            string keyWord = Misc.GetRegisterValue("SearchKeyWord").ToString();
            int searchMatchCase = (int)Misc.GetRegisterValue("SearchMatchCase");
            int searchDir = (int)Misc.GetRegisterValue("SearchDir");
            int searchCycle = (int)Misc.GetRegisterValue("SearchCycle");
            if (string.IsNullOrEmpty(Misc.searchKeyWord))
            {
                txtFindContent.Text = keyWord;
            }
            else
            {
                txtFindContent.Text = Misc.searchKeyWord;
            }
            ckbMatchCase.Checked = searchMatchCase == 1;
            rbtDirUp.Checked = searchDir == 1;
            ckbCycle.Checked = searchCycle == 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            string searchKeyWord = txtFindContent.Text;
            RichTextBoxFinds findOption = 0;
            if (ckbMatchCase.Checked)
            {
                findOption |= RichTextBoxFinds.MatchCase;
            }
            if (rbtDirUp.Checked)
            {
                findOption |= RichTextBoxFinds.Reverse;
            }
            Misc.searchKeyWord = searchKeyWord;
            Misc.currFindOption = findOption;
            if (ckbCycle.Checked)
            {
                findKeyWordCallBack(searchKeyWord, findOption, true);
                Misc.cycleFind = true;
            }
            else
            {
                findKeyWordCallBack(searchKeyWord, findOption, false);
                Misc.cycleFind = false;
            }
        }

        private void FindForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCancel)
            {
                //将搜索内容 当前设置都保存到注册表
                Misc.SetRegisterKV<string>("SearchKeyWord", txtFindContent.Text);
                Misc.SetRegisterKV<int>("SearchDir", rbtDirUp.Checked ? 1 : 0);
                Misc.SetRegisterKV<int>("SearchMatchCase", ckbMatchCase.Checked ? 1 : 0);
                Misc.SetRegisterKV<int>("SearchCycle", ckbCycle.Checked ? 1 : 0);
            }
        }
    }
}
