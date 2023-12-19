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
    public partial class ReplaceForm : Form
    {
        private Action<string, string, RichTextBoxFinds, bool> replaceKeyWordCallBack;
        private bool isCancel = false;
        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                replaceKeyWordCallBack = this.Tag as Action<string, string, RichTextBoxFinds, bool>;
            }
            string keyWord = Misc.GetRegisterValue("SearchKeyWord").ToString();
            object robj = Misc.GetRegisterValue("ReplaceKeyWord");
            int searchMatchCase = (int)Misc.GetRegisterValue("SearchMatchCase");
            int searchCycle = (int)Misc.GetRegisterValue("SearchCycle");
            if (string.IsNullOrEmpty(Misc.searchKeyWord))
            {
                txtFindContent.Text = keyWord;
            }
            else
            {
                txtFindContent.Text = Misc.searchKeyWord;
            }
            if (robj != null)
            {
                txtReplaceContent.Text = robj.ToString(); ;
            }
            ckbMatchCase.Checked = searchMatchCase == 1;
            ckbCycle.Checked = searchCycle == 1;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            Misc.currReplaceState = ReplaceState.Find;
            Misc.searchKeyWord = txtFindContent.Text;
            Misc.replaceWord = txtReplaceContent.Text;
            SaveSettingToReg();
            BeginReplace(Misc.searchKeyWord, Misc.replaceWord);
        }

        private void BeginReplace(string key, string replaceKey)
        {
            RichTextBoxFinds findOption = 0;
            if (ckbMatchCase.Checked)
            {
                findOption |= RichTextBoxFinds.MatchCase;
            }

            Misc.currFindOption = findOption;
            if (ckbCycle.Checked)
            {
                replaceKeyWordCallBack(key, replaceKey, findOption, true);
                Misc.cycleFind = true;
            }
            else
            {
                replaceKeyWordCallBack(key, replaceKey, findOption, false);
                Misc.cycleFind = false;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Misc.searchKeyWord = txtFindContent.Text;
            Misc.replaceWord = txtReplaceContent.Text;
            SaveSettingToReg();
            BeginReplace(Misc.searchKeyWord, Misc.replaceWord);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }

        private void SaveSettingToReg()
        {
            Misc.SetRegisterKV<string>("SearchKeyWord", txtFindContent.Text);
            Misc.SetRegisterKV<string>("ReplaceKeyWord", txtReplaceContent.Text);
            Misc.SetRegisterKV<int>("SearchMatchCase", ckbMatchCase.Checked ? 1 : 0);
            Misc.SetRegisterKV<int>("SearchCycle", ckbCycle.Checked ? 1 : 0);
        }

        private void ReplaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCancel)
            {
                SaveSettingToReg();
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            Misc.searchKeyWord = txtFindContent.Text;
            Misc.replaceWord = txtReplaceContent.Text;
            SaveSettingToReg();
            Misc.currReplaceState = ReplaceState.ReplaceAll;
            BeginReplace(Misc.searchKeyWord, Misc.replaceWord);
        }
    }
}
