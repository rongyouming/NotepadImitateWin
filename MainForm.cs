using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinNotepad
{
    enum UndoOrRedoType
    {
        UnKnow,
        Typing,
        Delete,
        DragDrop,
        Cut,
        Paste
    }

    enum UndoOrRedo
    {
        Undo,
        Redo
    }
    public partial class MainForm : Form
    {
        public static MainForm _instance;

        private bool fromDrop = false;

        private Font currFont;

        private UndoOrRedo undo_or_redo = UndoOrRedo.Undo;

        private Action<string, RichTextBoxFinds, bool> findKeyWordCallBack;
        private Action<string, string, RichTextBoxFinds, bool> replaceKeyWordCallBack;
        private Action<int> gotoLineCallBack;
        private Action<IntPtr, Control> setControlLocationCallBack;

        private int oldCaret;
        private const int encodingCboOffsetX = 397;
        private const int encodingCboOffsetY = 38;
        private MultiOpenFileDialog multiOpenFileDialog = new MultiOpenFileDialog();
        private MultiSaveFileDialog multiSaveFileDialog = new MultiSaveFileDialog();

        public string Title { get; set; }


        public MainForm()
        {
            InitializeComponent();
            InitializeComponentExtend();
            currFont = new Font("微软雅黑", 20);
            rTxtContent.Font = currFont;
            rTxtContent.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            rTxtContent.AutoWordSelection = false;
            findKeyWordCallBack = FindKeyWord;
            replaceKeyWordCallBack = ReplaceKeyWord;
            gotoLineCallBack = GotoLineCallBack;
            rTxtContent.HideSelection = false;
            _instance = this;
        }

        private void GotoLineCallBack(int lineNum)
        {
            int charIndex = rTxtContent.GetFirstCharIndexFromLine(lineNum - 1);
            rTxtContent.Select(charIndex, 0);
            rTxtContent.ScrollToCaret();
        }

        private bool Find(string keyWord, RichTextBoxFinds findOption, bool cycle)
        {
            if ((findOption & RichTextBoxFinds.Reverse) != RichTextBoxFinds.None)
            {
                //向前查找
                if (cycle)
                {
                    Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, 0, rTxtContent.SelectionStart, findOption);
                    if (Misc.currFoundKeyWordPos > 0)
                    {
                        Misc.currFoundKeyWordPos += keyWord.Length + 1;
                    }
                    else
                    {
                        Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, 0, 0, findOption);
                    }
                }
                else
                {
                    Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, 0, rTxtContent.SelectionStart, findOption);
                }
            }
            else
            {
                //向后查找
                if (rTxtContent.SelectionLength == 0 && rTxtContent.SelectionStart <= rTxtContent.TextLength && Misc.currFoundKeyWordPos == -1)
                {
                    Misc.currFoundKeyWordPos = rTxtContent.SelectionStart;
                }
                if (cycle)
                {
                    Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, Misc.currFoundKeyWordPos < 0 ? 0 : Misc.currFoundKeyWordPos, findOption);
                    if (Misc.currFoundKeyWordPos < 0)
                    {
                        Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, 0, findOption);
                    }
                }
                else
                {
                    if (Misc.currFoundKeyWordPos >= 0)
                    {
                        Misc.currFoundKeyWordPos = rTxtContent.Find(keyWord, Misc.currFoundKeyWordPos, findOption);
                    }
                }
                if (Misc.currFoundKeyWordPos >= 0)
                {
                    Misc.currFoundKeyWordPos += keyWord.Length;
                }
            }

            if (Misc.currFoundKeyWordPos != -1)
            {
                return true;
            }
            return false;
        }

        private void FindKeyWord(string keyWord, RichTextBoxFinds findOption, bool cycle)
        {
            if (Find(keyWord, findOption, cycle))
            {
                rTxtContent.Focus();
                //SelectionStart的位置在搜索到结果第一个字符的位置=foundPos
                rTxtContent.ScrollToCaret();
            }
            else
            {
                MessageBox.Show($"找不到\"{ keyWord }\"", this.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReplaceNext(string keyWord, RichTextBoxFinds findOption, bool cycle)
        {
            if (Find(keyWord, findOption, cycle))
            {
                rTxtContent.Focus();
                //SelectionStart的位置在搜索到结果第一个字符的位置=foundPos
                rTxtContent.ScrollToCaret();
                Misc.currReplaceState = ReplaceState.Replace;
            }
            else
            {
                Misc.currReplaceState = ReplaceState.Find;
                MessageBox.Show($"找不到\"{ keyWord }\"", this.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReplaceKeyWord(string keyWord, string replaceWord, RichTextBoxFinds findOption, bool cycle)
        {
            if (Misc.currReplaceState == ReplaceState.Find)
            {
                //查找
                ReplaceNext(keyWord, findOption, cycle);
            }
            else if (Misc.currReplaceState == ReplaceState.Replace)
            {
                //替换
                rTxtContent.SelectionLength = Misc.searchKeyWord.Length;
                rTxtContent.SelectedText = Misc.replaceWord;
                ReplaceNext(keyWord, findOption, cycle);
            }
            else
            {
                //全部替换
                string oldTxt = rTxtContent.Text;
                string newTxt;
                if ((findOption & RichTextBoxFinds.MatchCase) == RichTextBoxFinds.None)
                {
                    newTxt = Regex.Replace(oldTxt, Misc.searchKeyWord, Misc.replaceWord, RegexOptions.IgnoreCase);
                }
                else
                {
                    newTxt = Regex.Replace(oldTxt, Misc.searchKeyWord, Misc.replaceWord);
                }
                if (newTxt != oldTxt)
                {
                    Misc.oldContent = rTxtContent.Text;
                    rTxtContent.Text = newTxt;
                    Misc.speciallUndo = true;
                }
                Misc.currReplaceState = ReplaceState.Find;
                CheckUndoState();
            }
        }

        private void SetControlLocation(IntPtr parentHandle, Control childHandle)
        {
            NativeMethods.RECT currentSize = new NativeMethods.RECT();
            NativeMethods.GetClientRect(parentHandle, ref currentSize);
            childHandle.Location = new Point((int)currentSize.Width - encodingCboOffsetX, (int)currentSize.Height - encodingCboOffsetY);
        }

        private void SetTitle()
        {
            this.Text = $"{ContentManager.Instance.fileName} - {this.Title}";
        }

        private bool CheckUndoState()
        {
            int undoId = unchecked((int)NativeMethods.SendMessage(rTxtContent.Handle, NativeMethods.EM_GETUNDONAME, 0, 0));
            int redoId = unchecked((int)NativeMethods.SendMessage(rTxtContent.Handle, NativeMethods.EM_GETREDONAME, 0, 0));
            if ((UndoOrRedoType)redoId != UndoOrRedoType.UnKnow && Misc.speciallUndo)
            {
                Misc.speciallUndo = false;
                undo_or_redo = UndoOrRedo.Undo;
                subUndo.Text = "撤销";
            }
            if ((UndoOrRedoType)undoId == UndoOrRedoType.DragDrop && undo_or_redo == UndoOrRedo.Undo)
            {
                subUndo.Enabled = false;
                return false;
            }
            if ((UndoOrRedoType)redoId == UndoOrRedoType.DragDrop && undo_or_redo == UndoOrRedo.Redo)
            {
                subUndo.Enabled = false;
                return false;
            }
            if (!rTxtContent.CanUndo && !rTxtContent.CanRedo && Misc.speciallUndo == false)
            {
                subUndo.Enabled = false;
                return false;
            }
            else
            {
                subUndo.Enabled = true;
                return true;
            }

        }

        //是否可以复制 剪切 删除 选中状态才可以
        private void CheckEditState()
        {
            if (rTxtContent.SelectedText.Length > 0)
            {
                subCopy.Enabled = true;
                subCut.Enabled = true;
                subDelete.Enabled = true;
            }
            else
            {
                subCopy.Enabled = false;
                subCut.Enabled = false;
                subDelete.Enabled = false;
            }
            if (rTxtContent.CanPaste(DataFormats.GetFormat(DataFormats.Text)))
            {
                subPaste.Enabled = true;
            }
            else
            {
                subPaste.Enabled = false;
            }
        }

        private void CheckFindState()
        {
            if (rTxtContent.Text.Length == 0)
            {
                subFind.Enabled = false;
                subFindNext.Enabled = false;
                subFindLast.Enabled = false;
            }
            else
            {
                subFind.Enabled = true;
                subFindNext.Enabled = true;
                subFindLast.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Title = this.Text;
            this.Text = $"{ContentManager.Instance.fileName} - {this.Title}";
            rTxtContent.AllowDrop = true;
            rTxtContent.Font = Misc.GetFontFromRegister();
            object robj = Misc.GetRegisterValue("WordWrapState");
            if (robj != null)
            {
                int wordWrapState = (int)robj;
                if (wordWrapState == 1)
                {
                    subWordWrop.Checked = true;

                }
                else
                {
                    subWordWrop.Checked = false;
                }
                rTxtContent.WordWrap = subWordWrop.Checked;
                rTxtContent.Select(0, 0);
                rTxtContent.ClearUndo();
            }
            robj = Misc.GetRegisterValue("ShowStatusBar");
            if (robj != null)
            {
                int state = (int)robj;
                if (state == 1)
                {
                    subShowStatus.Checked = true;
                }
                else
                {
                    subShowStatus.Checked = false;
                }
                statusStrip1.Visible = subShowStatus.Checked;
            }
            subZoomIn.ShortcutKeyDisplayString = "Ctrl+加号";
            subZoomOut.ShortcutKeyDisplayString = "Ctrl+减号";
            SetStatusLabelWidth();
            SetStatusBar();
            CheckUndoState();
            CheckEditState();
            CheckFindState();
            setControlLocationCallBack = SetControlLocation;
            cbowlDropDownEncoding.InnerComboBox.SelectedIndexChanged += InnerComboBox_DropDownEncoding_SelectedIndexChanged;
            cbowlSaveEncoding.InnerComboBox.SelectedIndexChanged += InnerComboBox_SaveEncoding_SelectedIndexChanged;
        }

        private void InnerComboBox_SaveEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            Misc.selectEncodingIndex = cbo.SelectedIndex;

        }

        private void InnerComboBox_DropDownEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            Misc.selectEncodingIndex = cbo.SelectedIndex;
        }

        //窗口宽度伸缩时 让状态栏各项有一个折叠效果
        private void SetStatusLabelWidth()
        {
            //减掉20像素(估计值)是因为右下角有一个调节角标 不能算进宽度里
            int TotalWidth = statusStrip1.Width - 20;
            for (int i = statusStrip1.Items.Count - 1; i >= 0; i--)
            {
                CustomToolStripStatusLabel curr = (CustomToolStripStatusLabel)statusStrip1.Items[i];
                if (TotalWidth <= 0)
                {
                    curr.Width = 0;
                    continue;
                }
                if (curr.MaxWidth > 0)
                {
                    if (TotalWidth >= curr.MaxWidth)
                    {
                        curr.Width = curr.MaxWidth;
                        TotalWidth -= curr.MaxWidth;
                    }
                    else
                    {
                        curr.Width = TotalWidth;
                        TotalWidth = 0;
                    }
                }
                else
                {
                    curr.Width = TotalWidth;
                    TotalWidth = 0;
                }
            }
        }

        private void subExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void subNewWindow_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void rTxtContent_TextChanged(object sender, EventArgs e)
        {
            //rTxtContent.Font = new Font("微软雅黑", 14);
            CheckFindState();
            Misc.lineCount = rTxtContent.Lines.Length;
            if (rTxtContent.Text.Length == 0)
            {
                Misc.currFoundKeyWordPos = -1;
            }
            if (ContentManager.Instance.isNewFile && rTxtContent.Text.Length == 0 || fromDrop)
            {
                ContentManager.Instance.isNewFile = false;
                rTxtContent.ClearUndo();
                CheckUndoState();
                fromDrop = false;
                return;
            }
            if (!Misc.speciallUndo)
            {
                undo_or_redo = UndoOrRedo.Undo;
            }
            CheckUndoState();

            ContentManager.Instance.isNewFile = false;
            if (!ContentManager.Instance.hasSave && rTxtContent.Text.Length == 0)
            {
                ContentManager.Instance.hasEdit = false;
                this.Text = $"{ContentManager.Instance.fileName} - {this.Title}";
            }
            else
            {
                ContentManager.Instance.hasEdit = true;
                this.Text = $"*{ContentManager.Instance.fileName} - {this.Title}";
            }
        }

        private void sunNewFile_Click(object sender, EventArgs e)
        {
            ContentManager.Instance.SetNewFile();
            this.Text = $"{ContentManager.Instance.fileName} - {this.Title}";
            this.Update();
            rTxtContent.Text = string.Empty;
            SetStatusBar();
        }

        private void subOpenFile_Click(object sender, EventArgs e)
        {
            cbowlDropDownEncoding.InnerComboBox.SelectedIndex = 0;
            multiOpenFileDialog.setControlLocationDlg = setControlLocationCallBack;
            multiOpenFileDialog.Multiselect = false;
            multiOpenFileDialog.Title = "打开";
            multiOpenFileDialog.Filter = "文本文件|*.txt|所有文件|*.*"; //设置要选择的文件的类型
            multiOpenFileDialog.FileName = string.Empty;
            if (multiOpenFileDialog.ShowDialog(this, cbowlDropDownEncoding) == DialogResult.OK)
            {
                rTxtContent.Text = ContentManager.Instance.ReadFile(multiOpenFileDialog.FileName);
                //rTxtContent.Text = File.ReadAllText(multiOpenFileDialog.FileName);
                ContentManager.Instance.hasEdit = false;
                ContentManager.Instance.SetFileName(Path.GetFileName(multiOpenFileDialog.FileName));
                ContentManager.Instance.SetFilePath(multiOpenFileDialog.FileName);
                SetTitle();
                SetStatusBar();
            }
        }

        private void rTxtContent_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void rTxtContent_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fileName in files)
            {
                fromDrop = true;
                rTxtContent.Text = ContentManager.Instance.ReadFile(fileName);
                ContentManager.Instance.SetFileName(Path.GetFileName(fileName));
                ContentManager.Instance.SetFilePath(fileName);
                SetTitle();
                rTxtContent.ClearUndo();
            }
        }

        private bool DoSave(string title)
        {
            multiSaveFileDialog.setControlLocationDlg = setControlLocationCallBack;
            multiSaveFileDialog.Title = title;
            multiSaveFileDialog.Filter = "文本文件|*.txt|所有文件|*.*"; //设置要保存的文件的类型
            multiSaveFileDialog.FileName = string.Empty;
            multiSaveFileDialog.AddExtension = true;
            if (!ContentManager.Instance.hasSave)
            {
                cbowlSaveEncoding.InnerComboBox.SelectedIndex = (int)(int)EncodingTypeWhenSave.UTF8;
            }
            else
            {
                cbowlSaveEncoding.InnerComboBox.SelectedIndex = Misc.selectEncodingIndex;
            }
            if (multiSaveFileDialog.ShowDialog(this, cbowlSaveEncoding) == DialogResult.OK)
            {
                ContentManager.Instance.SaveFile(multiSaveFileDialog.FileName, rTxtContent.Text);
                ContentManager.Instance.SetFileName(Path.GetFileName(multiSaveFileDialog.FileName));
                ContentManager.Instance.SetFilePath(multiSaveFileDialog.FileName);
                SetTitle();
                SetStatusBar();
                return true;
            }
            return false;
        }

        private void subSaveFile_Click(object sender, EventArgs e)
        {
            //只读文件只能另存为
            if (ContentManager.Instance.currFileAccess == FileAccess.Read)
            {
                if (DoSave("另存为"))
                {
                    SetTitle();
                    ContentManager.Instance.hasEdit = false;
                    return;
                }
                return;
            }
            if (!ContentManager.Instance.hasSave)
            {
                if (DoSave("保存"))
                {
                    ContentManager.Instance.hasEdit = false;
                }
            }
            else
            {
                ContentManager.Instance.SaveFileContinue(rTxtContent.Text);
                SetTitle();
                ContentManager.Instance.hasEdit = false;
            }
            SetStatusBar();
        }

        private void subSaveAsFile_Click(object sender, EventArgs e)
        {
            if (DoSave("另存为"))
            {
                ContentManager.Instance.hasEdit = false;
            }
            SetStatusBar();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //如果切到别的窗口或桌面去复制 再切回来的时候 需要判断刚刚复制的东西能不能粘贴
            CheckEditState();
        }

        private void subPagePreview_Click(object sender, EventArgs e)
        {
            pageSetupDialog.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog.ShowDialog();
        }

        private void subPrint_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();

            //rTxtContent.Text = rTxtContent.Text.Replace("\n", "");

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ContentManager.Instance.hasEdit)
            {
                DialogResult result = MessageBoxEx.Show($"你想更改保存到 {ContentManager.Instance.fileName} 吗？", this.Title, MessageBoxButtons.YesNoCancel, new string[] { "保存", "不保存", "取消" });
                if (result == DialogResult.Yes)
                {
                    //保存
                    if (!ContentManager.Instance.hasSave)
                    {
                        //打开保存对话框 然后确实保存了
                        if (DoSave("保存"))
                        {
                            Application.ExitThread();
                        }
                        else
                        {
                            //反悔了 不保存
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        ContentManager.Instance.SaveFileContinue(rTxtContent.Text);
                        Application.ExitThread();
                    }
                }
                else if (result == DialogResult.No)
                {
                    //不保存
                    Application.ExitThread();
                }
                else
                {
                    //取消
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void subUndo_Click(object sender, EventArgs e)
        {
            rTxtContent.Focus();
            if (undo_or_redo == UndoOrRedo.Undo)
            {
                rTxtContent.Undo();
                undo_or_redo = UndoOrRedo.Redo;
                subUndo.Text = "重做";
                CheckUndoState();
                if (Misc.speciallUndo)
                {
                    rTxtContent.Text = Misc.oldContent;
                    rTxtContent.Focus();
                    rTxtContent.SelectionStart = rTxtContent.TextLength;
                    rTxtContent.ScrollToCaret();
                    rTxtContent.SelectAll();
                }

            }
            else
            {
                rTxtContent.Redo();
                undo_or_redo = UndoOrRedo.Undo;
                subUndo.Text = "撤销";
                CheckUndoState();
                if (Misc.speciallUndo)
                {
                    rTxtContent.SelectionStart = 0;
                    rTxtContent.ScrollToCaret();
                    Misc.currReplaceState = ReplaceState.ReplaceAll;
                    ReplaceKeyWord(Misc.searchKeyWord, Misc.replaceWord, Misc.currFindOption, Misc.cycleFind);
                    rTxtContent.Focus();

                }
            }
            if (rTxtContent.Text.Length == 0 && !ContentManager.Instance.hasSave)
            {
                ContentManager.Instance.isNewFile = true;
                ContentManager.Instance.hasEdit = false;
                SetTitle();
            }

        }

        private void subCopy_Click(object sender, EventArgs e)
        {
            rTxtContent.Copy();
        }

        private void subCut_Click(object sender, EventArgs e)
        {
            rTxtContent.Cut();
        }

        private void subPaste_Click(object sender, EventArgs e)
        {
            //只能粘贴文本的内容
            rTxtContent.Paste(DataFormats.GetFormat(DataFormats.Text));
        }

        private void subDelete_Click(object sender, EventArgs e)
        {
            rTxtContent.Focus();
            //发送delete键消息 执行删除操作
            NativeMethods.keybd_event(0x2E, 0, 1, UIntPtr.Zero);
        }

        private void rTxtContent_SelectionChanged(object sender, EventArgs e)
        {
            //光标定位 选中都会触发这个事件
            CheckEditState();
            if (rTxtContent.SelectedText.Length == 0)
            {
                Misc.currFoundKeyWordPos = -1;
            }
            if (rTxtContent.SelectedText.Length == 0)
            {
                Misc.currReplaceState = ReplaceState.Find;
            }
            if (rTxtContent.SelectionLength == 0)
            {
                oldCaret = rTxtContent.SelectionStart;
            }
            SetStatusBar();
        }

        private void rTxtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                IDataObject dataObject = Clipboard.GetDataObject();
                if (dataObject.GetDataPresent(DataFormats.StringFormat))
                {
                    e.Handled = true;
                    var content = (string)Clipboard.GetData(DataFormats.StringFormat);
                    Clipboard.Clear();
                    Clipboard.SetData(DataFormats.StringFormat, content);
                    rTxtContent.Paste();
                }
            }
        }

        private void subFind_Click(object sender, EventArgs e)
        {
            Misc.searchKeyWord = rTxtContent.SelectedText;
            OpenFindWindow();
            //rTxtContent.Find
        }

        private void subFindNext_Click(object sender, EventArgs e)
        {
            if (Misc.searchKeyWord == string.Empty)
            {
                OpenFindWindow();
            }
            else
            {
                Find(Misc.searchKeyWord, Misc.currFindOption, Misc.cycleFind);
            }
        }

        private void subFindLast_Click(object sender, EventArgs e)
        {
            if (Misc.searchKeyWord == string.Empty)
            {
                OpenFindWindow();
            }
            else
            {
                Find(Misc.searchKeyWord, Misc.currFindOption | RichTextBoxFinds.Reverse, Misc.cycleFind);
            }
        }

        private void OpenFindWindow()
        {
            if (CheckForm(typeof(FindForm).Name))
            {
                Form curr = GetFormByName(typeof(FindForm).Name);
                curr.Close();
            }
            //查找窗口和替换窗口是互斥的 一个打开另一个就要关闭
            Form replaceForm = GetFormByName(typeof(ReplaceForm).Name);
            if (replaceForm != null && !replaceForm.IsDisposed)
            {
                replaceForm.Close();
            }
            CreateNewFindForm();
        }

        private void subReplace_Click(object sender, EventArgs e)
        {
            if (rTxtContent.SelectionLength > 0)
            {
                Misc.currReplaceState = ReplaceState.Replace;
            }
            Misc.searchKeyWord = rTxtContent.SelectedText;
            OpenReplaceForm();
        }

        private void OpenReplaceForm()
        {
            if (CheckForm(typeof(ReplaceForm).Name))
            {
                Form curr = GetFormByName(typeof(ReplaceForm).Name);
                curr.Close();
            }
            Form findForm = GetFormByName(typeof(FindForm).Name);
            if (findForm != null && !findForm.IsDisposed)
            {
                findForm.Close();
            }
            CreateNewReplaceForm();
        }

        private void CreateNewFindForm()
        {
            FindForm findForm = new FindForm();
            findForm.ShowInTaskbar = false;

            findForm.Tag = findKeyWordCallBack;
            findForm.Location = Misc.GetFormShowPosition(this, findForm);
            findForm.Show();
        }

        private void CreateNewReplaceForm()
        {
            ReplaceForm replaceForm = new ReplaceForm();
            replaceForm.ShowInTaskbar = false;

            replaceForm.Tag = replaceKeyWordCallBack;
            replaceForm.Location = Misc.GetFormShowPosition(this, replaceForm);
            replaceForm.Show();
        }

        private bool CheckForm(string formName)
        {
            bool b_isOpen = false;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == formName)
                {
                    b_isOpen = true;
                    item.Activate();
                    break;
                }
            }
            return b_isOpen;
        }

        private Form GetFormByName(string formName)
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == formName)
                {
                    return item;
                }
            }
            return null;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            SetStatusLabelWidth();
        }

        private Point CalcRowNum(int charIndex)
        {
            int total = 0;
            int start;
            int end;
            int row = 0;
            int col = 0;
            for (int i = 0; i < rTxtContent.Lines.Length; i++)
            {
                start = total;
                total += rTxtContent.Lines[i].Length + 1;
                end = total;

                if (charIndex > start && charIndex <= end)
                {
                    row = i;
                    col = charIndex - start;
                    break;
                }
            }
            try
            {
                int k = charIndex;
                if (k - 1 >= rTxtContent.TextLength)
                {
                    k -= 1;
                }
                if ((col > 1 && k > 0 && rTxtContent.Text[k - 1] == '\n') || rTxtContent.Lines[row].Length == 0)
                {
                    col = rTxtContent.Lines[row].Length;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return new Point(row, col);
        }
        bool supressSetStatusBar = false;
        private void SetStatusBar()
        {
            if (supressSetStatusBar)
            {
                supressSetStatusBar = false;
                return;
            }
            stLblFileAttr.Text = Misc.GetFileAttrName();
            Point caretPoint;
            NativeMethods.GetCaretPos(out caretPoint);
            int SelEnd = rTxtContent.GetCharIndexFromPosition(caretPoint);
            //NativeMethods.SendMessage(rTxtContent.Handle, NativeMethods.EM_GETSEL, ref SelStart, ref SelEnd);
            int currCharIndex;
            if (SelEnd >= oldCaret)
            {
                currCharIndex = oldCaret + rTxtContent.SelectionLength;
            }
            else
            {
                currCharIndex = oldCaret - rTxtContent.SelectionLength;
            }

            if (rTxtContent.SelectionLength > 0)
            {
                Point pos = CalcRowNum(currCharIndex);
                stLblColAndRow.Text = $"第 {pos.X + 1} 行,第 {pos.Y + 1} 列";
            }
            else
            {
                int row = rTxtContent.GetLineFromCharIndex(currCharIndex);
                int col = rTxtContent.SelectionStart + rTxtContent.SelectionLength - rTxtContent.GetFirstCharIndexFromLine(row);
                stLblColAndRow.Text = $"第 {row + 1} 行,第 {col + 1} 列";
            }
            UpdateLblZoomFactor();
            stLblEncodingName.Text = ContentManager.Instance.currCodeType.EncodingName;
        }

        private void UpdateLblZoomFactor()
        {
            stLblZoomFactor.Text = $"{100 + Misc.scaleFactor * 10}%";
        }

        private void subGoto_Click(object sender, EventArgs e)
        {
            GotoForm gotoForm = new GotoForm();
            gotoForm.ShowInTaskbar = false;
            //gotoForm.Location = Misc.GetFormShowPosition(this, gotoForm);
            gotoForm.Tag = gotoLineCallBack;
            gotoForm.ShowDialog();
        }

        private void subSelectAll_Click(object sender, EventArgs e)
        {
            rTxtContent.Select(0, rTxtContent.TextLength);
        }

        private void subInsertDate_Click(object sender, EventArgs e)
        {
            rTxtContent.SelectedText = DateTime.Now.ToString("HH:mm yyyy/MM/dd");
        }

        private void subWordWrop_Click(object sender, EventArgs e)
        {
            supressSetStatusBar = true;
            rTxtContent.WordWrap = !rTxtContent.WordWrap;
            if (rTxtContent.WordWrap)
            {
                subWordWrop.Checked = true;
            }
            else
            {
                subWordWrop.Checked = false;
            }
            Misc.SetRegisterKV<int>("WordWrapState", rTxtContent.WordWrap ? 1 : 0);
            rTxtContent.Select(0, 0);
            rTxtContent.ClearUndo();
            CheckUndoState();
        }

        private void subFont_Click(object sender, EventArgs e)
        {
            MultiFontDialog fontDialog = new MultiFontDialog();
            fontDialog.AllowScriptChange = true;
            fontDialog.currFont = rTxtContent.Font;
            fontDialog.setChildControlDlg = SetFontDialogChildControl;
            fontDialog.setResultOkDlg = SetWhenFontDialogReslutOk;
            //Console.WriteLine(fontDialog.currFont.GdiCharSet);
            if (fontDialog.ShowDialog(this, null) == DialogResult.OK)
            {
                //字体的属性比较多 直接将字体对象序列化之后保存二进制数据就可以了
                //要设置字体的时候再反序列化出来
                rTxtContent.Font = fontDialog.currFont;
                BinaryFormatter binFormat = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                binFormat.Serialize(ms, fontDialog.currFont);
                Misc.SetRegisterFromStream("FontData", ms);
                ms.Close();
            }
        }

        private IntPtr hwd_font_script_combox = IntPtr.Zero;
        private ComboBoxNativeWindow childNative=null;
        public void SetFontDialogChildControl(IntPtr parentHandle, IntPtr childHandle)
        {         
            int controlId = NativeMethods.GetDlgCtrlID(childHandle);
            if (controlId == NativeMethods.FONT_SCRIPT_COMBOBOX_RCID)
            {
                hwd_font_script_combox = childHandle;
                childNative = new ComboBoxNativeWindow(childHandle);
                object objVal = Misc.GetRegisterValue("FontCharSetIdx");
                Misc.charsetIndex = objVal == null ? 0 : (int)objVal;
                NativeMethods.SendMessage(childHandle, NativeMethods.CB_SETCURSEL, Misc.charsetIndex, 0);
            }
        }

        public void SetWhenFontDialogReslutOk()
        {
            if (hwd_font_script_combox != IntPtr.Zero)
            {
                Misc.SetRegisterKV("FontCharSetIdx", Misc.charsetIndex);
            }
        }

        private void subZoomIn_Click(object sender, EventArgs e)
        {
            if (Misc.scaleFactor < 40)
            {
                Misc.scaleFactor += 1;
                rTxtContent.ZoomFactor = 1 + 0.1F * Misc.scaleFactor;
                UpdateLblZoomFactor();
            }
        }

        private void subZoomOut_Click(object sender, EventArgs e)
        {
            if (Misc.scaleFactor > -9)
            {
                Misc.scaleFactor -= 1;
                rTxtContent.ZoomFactor = 1 + 0.1F * Misc.scaleFactor;
                UpdateLblZoomFactor();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Add)
                {
                    subZoomIn_Click(null, null);
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    subZoomOut_Click(null, null);
                }
                else if (e.KeyCode == Keys.NumPad0)
                {
                    subZoomReset_Click(null, null);
                }
            }
        }

        private void subZoomReset_Click(object sender, EventArgs e)
        {
            Misc.scaleFactor = 0;
            rTxtContent.ZoomFactor = 1;
            UpdateLblZoomFactor();
        }

        private void subShowStatus_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
            subShowStatus.Checked = !subShowStatus.Checked;
            Misc.SetRegisterKV<int>("ShowStatusBar", statusStrip1.Visible ? 1 : 0);
        }


    }
}
