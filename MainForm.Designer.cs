
namespace WinNotepad
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sunNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.subOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.subPagePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.subPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.subExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.subCut = new System.Windows.Forms.ToolStripMenuItem();
            this.subCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.subPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.subDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.subFind = new System.Windows.Forms.ToolStripMenuItem();
            this.subFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.subFindLast = new System.Windows.Forms.ToolStripMenuItem();
            this.subReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.subGoto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.subSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.subInsertDate = new System.Windows.Forms.ToolStripMenuItem();
            this.formatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subWordWrop = new System.Windows.Forms.ToolStripMenuItem();
            this.subFont = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.subZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.subZoomReset = new System.Windows.Forms.ToolStripMenuItem();
            this.subShowStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送反馈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.关于记事本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLblFileAttr = new WinNotepad.CustomToolStripStatusLabel();
            this.stLblColAndRow = new WinNotepad.CustomToolStripStatusLabel();
            this.stLblZoomFactor = new WinNotepad.CustomToolStripStatusLabel();
            this.customToolStripStatusLabel4 = new WinNotepad.CustomToolStripStatusLabel();
            this.stLblEncodingName = new WinNotepad.CustomToolStripStatusLabel();
            this.rTxtContent = new WinNotepad.CustomRichTextBox();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.White;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.formatMenu,
            this.viewMenu,
            this.帮助ToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mainMenu.Size = new System.Drawing.Size(691, 30);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sunNewFile,
            this.subNewWindow,
            this.subOpenFile,
            this.subSaveFile,
            this.subSaveAsFile,
            this.toolStripSeparator1,
            this.subPagePreview,
            this.subPrint,
            this.toolStripSeparator2,
            this.subExit});
            this.fileMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(53, 24);
            this.fileMenu.Text = "文件";
            // 
            // sunNewFile
            // 
            this.sunNewFile.Name = "sunNewFile";
            this.sunNewFile.Size = new System.Drawing.Size(236, 26);
            this.sunNewFile.Text = "新建";
            this.sunNewFile.Click += new System.EventHandler(this.sunNewFile_Click);
            // 
            // subNewWindow
            // 
            this.subNewWindow.Name = "subNewWindow";
            this.subNewWindow.Size = new System.Drawing.Size(236, 26);
            this.subNewWindow.Text = "新窗口";
            this.subNewWindow.Click += new System.EventHandler(this.subNewWindow_Click);
            // 
            // subOpenFile
            // 
            this.subOpenFile.Name = "subOpenFile";
            this.subOpenFile.Size = new System.Drawing.Size(236, 26);
            this.subOpenFile.Text = "打开";
            this.subOpenFile.Click += new System.EventHandler(this.subOpenFile_Click);
            // 
            // subSaveFile
            // 
            this.subSaveFile.Name = "subSaveFile";
            this.subSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.subSaveFile.Size = new System.Drawing.Size(236, 26);
            this.subSaveFile.Text = "保存";
            this.subSaveFile.Click += new System.EventHandler(this.subSaveFile_Click);
            // 
            // subSaveAsFile
            // 
            this.subSaveAsFile.Name = "subSaveAsFile";
            this.subSaveAsFile.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.subSaveAsFile.Size = new System.Drawing.Size(236, 26);
            this.subSaveAsFile.Text = "另存为";
            this.subSaveAsFile.Click += new System.EventHandler(this.subSaveAsFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // subPagePreview
            // 
            this.subPagePreview.Name = "subPagePreview";
            this.subPagePreview.Size = new System.Drawing.Size(236, 26);
            this.subPagePreview.Text = "打印预览";
            this.subPagePreview.Click += new System.EventHandler(this.subPagePreview_Click);
            // 
            // subPrint
            // 
            this.subPrint.Name = "subPrint";
            this.subPrint.Size = new System.Drawing.Size(236, 26);
            this.subPrint.Text = "打印";
            this.subPrint.Click += new System.EventHandler(this.subPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(233, 6);
            // 
            // subExit
            // 
            this.subExit.Name = "subExit";
            this.subExit.Size = new System.Drawing.Size(236, 26);
            this.subExit.Text = "退出";
            this.subExit.Click += new System.EventHandler(this.subExit_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subUndo,
            this.toolStripSeparator3,
            this.subCut,
            this.subCopy,
            this.subPaste,
            this.subDelete,
            this.toolStripSeparator4,
            this.subFind,
            this.subFindNext,
            this.subFindLast,
            this.subReplace,
            this.subGoto,
            this.toolStripSeparator5,
            this.subSelectAll,
            this.subInsertDate});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(53, 24);
            this.editMenu.Text = "编辑";
            // 
            // subUndo
            // 
            this.subUndo.Name = "subUndo";
            this.subUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.subUndo.Size = new System.Drawing.Size(237, 26);
            this.subUndo.Text = "撤销";
            this.subUndo.Click += new System.EventHandler(this.subUndo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // subCut
            // 
            this.subCut.Name = "subCut";
            this.subCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.subCut.Size = new System.Drawing.Size(237, 26);
            this.subCut.Text = "剪切";
            this.subCut.Click += new System.EventHandler(this.subCut_Click);
            // 
            // subCopy
            // 
            this.subCopy.Name = "subCopy";
            this.subCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.subCopy.Size = new System.Drawing.Size(237, 26);
            this.subCopy.Text = "复制";
            this.subCopy.Click += new System.EventHandler(this.subCopy_Click);
            // 
            // subPaste
            // 
            this.subPaste.Name = "subPaste";
            this.subPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.subPaste.Size = new System.Drawing.Size(237, 26);
            this.subPaste.Text = "粘贴";
            this.subPaste.Click += new System.EventHandler(this.subPaste_Click);
            // 
            // subDelete
            // 
            this.subDelete.Name = "subDelete";
            this.subDelete.Size = new System.Drawing.Size(237, 26);
            this.subDelete.Text = "删除";
            this.subDelete.Click += new System.EventHandler(this.subDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // subFind
            // 
            this.subFind.Name = "subFind";
            this.subFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.subFind.Size = new System.Drawing.Size(237, 26);
            this.subFind.Text = "查找";
            this.subFind.Click += new System.EventHandler(this.subFind_Click);
            // 
            // subFindNext
            // 
            this.subFindNext.Name = "subFindNext";
            this.subFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.subFindNext.Size = new System.Drawing.Size(237, 26);
            this.subFindNext.Text = "查找下一个";
            this.subFindNext.Click += new System.EventHandler(this.subFindNext_Click);
            // 
            // subFindLast
            // 
            this.subFindLast.Name = "subFindLast";
            this.subFindLast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.subFindLast.Size = new System.Drawing.Size(237, 26);
            this.subFindLast.Text = "查找上一个";
            this.subFindLast.Click += new System.EventHandler(this.subFindLast_Click);
            // 
            // subReplace
            // 
            this.subReplace.Name = "subReplace";
            this.subReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.subReplace.Size = new System.Drawing.Size(237, 26);
            this.subReplace.Text = "替换";
            this.subReplace.Click += new System.EventHandler(this.subReplace_Click);
            // 
            // subGoto
            // 
            this.subGoto.Name = "subGoto";
            this.subGoto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.subGoto.Size = new System.Drawing.Size(237, 26);
            this.subGoto.Text = "转到";
            this.subGoto.Click += new System.EventHandler(this.subGoto_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(234, 6);
            // 
            // subSelectAll
            // 
            this.subSelectAll.Name = "subSelectAll";
            this.subSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.subSelectAll.Size = new System.Drawing.Size(237, 26);
            this.subSelectAll.Text = "全选";
            this.subSelectAll.Click += new System.EventHandler(this.subSelectAll_Click);
            // 
            // subInsertDate
            // 
            this.subInsertDate.Name = "subInsertDate";
            this.subInsertDate.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.subInsertDate.Size = new System.Drawing.Size(237, 26);
            this.subInsertDate.Text = "时间/日期";
            this.subInsertDate.Click += new System.EventHandler(this.subInsertDate_Click);
            // 
            // formatMenu
            // 
            this.formatMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subWordWrop,
            this.subFont});
            this.formatMenu.Name = "formatMenu";
            this.formatMenu.Size = new System.Drawing.Size(53, 24);
            this.formatMenu.Text = "格式";
            // 
            // subWordWrop
            // 
            this.subWordWrop.Name = "subWordWrop";
            this.subWordWrop.Size = new System.Drawing.Size(152, 26);
            this.subWordWrop.Text = "自动换行";
            this.subWordWrop.Click += new System.EventHandler(this.subWordWrop_Click);
            // 
            // subFont
            // 
            this.subFont.Name = "subFont";
            this.subFont.Size = new System.Drawing.Size(152, 26);
            this.subFont.Text = "字体";
            this.subFont.Click += new System.EventHandler(this.subFont_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenu,
            this.subShowStatus});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(53, 24);
            this.viewMenu.Text = "查看";
            // 
            // zoomMenu
            // 
            this.zoomMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subZoomIn,
            this.subZoomOut,
            this.subZoomReset});
            this.zoomMenu.Name = "zoomMenu";
            this.zoomMenu.Size = new System.Drawing.Size(137, 26);
            this.zoomMenu.Text = "缩放";
            // 
            // subZoomIn
            // 
            this.subZoomIn.Name = "subZoomIn";
            this.subZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.subZoomIn.Size = new System.Drawing.Size(247, 26);
            this.subZoomIn.Text = "放大";
            this.subZoomIn.Click += new System.EventHandler(this.subZoomIn_Click);
            // 
            // subZoomOut
            // 
            this.subZoomOut.Name = "subZoomOut";
            this.subZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.subZoomOut.Size = new System.Drawing.Size(247, 26);
            this.subZoomOut.Text = "缩小";
            this.subZoomOut.Click += new System.EventHandler(this.subZoomOut_Click);
            // 
            // subZoomReset
            // 
            this.subZoomReset.Name = "subZoomReset";
            this.subZoomReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.subZoomReset.Size = new System.Drawing.Size(247, 26);
            this.subZoomReset.Text = "恢复默认缩放";
            this.subZoomReset.Click += new System.EventHandler(this.subZoomReset_Click);
            // 
            // subShowStatus
            // 
            this.subShowStatus.Name = "subShowStatus";
            this.subShowStatus.Size = new System.Drawing.Size(137, 26);
            this.subShowStatus.Text = "状态栏";
            this.subShowStatus.Click += new System.EventHandler(this.subShowStatus_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.发送反馈ToolStripMenuItem,
            this.toolStripSeparator6,
            this.关于记事本ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            // 
            // 发送反馈ToolStripMenuItem
            // 
            this.发送反馈ToolStripMenuItem.Name = "发送反馈ToolStripMenuItem";
            this.发送反馈ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.发送反馈ToolStripMenuItem.Text = "发送反馈";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(164, 6);
            // 
            // 关于记事本ToolStripMenuItem
            // 
            this.关于记事本ToolStripMenuItem.Name = "关于记事本ToolStripMenuItem";
            this.关于记事本ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.关于记事本ToolStripMenuItem.Text = "关于记事本";
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLblFileAttr,
            this.stLblColAndRow,
            this.stLblZoomFactor,
            this.customToolStripStatusLabel4,
            this.stLblEncodingName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(691, 30);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stLblFileAttr
            // 
            this.stLblFileAttr.AutoSize = false;
            this.stLblFileAttr.BackColor = System.Drawing.SystemColors.Control;
            this.stLblFileAttr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stLblFileAttr.MaxWidth = -1;
            this.stLblFileAttr.Name = "stLblFileAttr";
            this.stLblFileAttr.Size = new System.Drawing.Size(150, 24);
            this.stLblFileAttr.Text = "操作类型";
            this.stLblFileAttr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stLblColAndRow
            // 
            this.stLblColAndRow.AutoSize = false;
            this.stLblColAndRow.BackColor = System.Drawing.SystemColors.Control;
            this.stLblColAndRow.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.stLblColAndRow.MaxWidth = 135;
            this.stLblColAndRow.Name = "stLblColAndRow";
            this.stLblColAndRow.Size = new System.Drawing.Size(135, 24);
            this.stLblColAndRow.Text = "abc";
            this.stLblColAndRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stLblZoomFactor
            // 
            this.stLblZoomFactor.AutoSize = false;
            this.stLblZoomFactor.BackColor = System.Drawing.SystemColors.Control;
            this.stLblZoomFactor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.stLblZoomFactor.MaxWidth = 50;
            this.stLblZoomFactor.Name = "stLblZoomFactor";
            this.stLblZoomFactor.Size = new System.Drawing.Size(50, 24);
            this.stLblZoomFactor.Text = "def";
            this.stLblZoomFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customToolStripStatusLabel4
            // 
            this.customToolStripStatusLabel4.AutoSize = false;
            this.customToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.customToolStripStatusLabel4.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.customToolStripStatusLabel4.MaxWidth = 120;
            this.customToolStripStatusLabel4.Name = "customToolStripStatusLabel4";
            this.customToolStripStatusLabel4.Size = new System.Drawing.Size(120, 24);
            this.customToolStripStatusLabel4.Text = "Windows(CRLF)";
            this.customToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stLblEncodingName
            // 
            this.stLblEncodingName.AutoSize = false;
            this.stLblEncodingName.BackColor = System.Drawing.SystemColors.Control;
            this.stLblEncodingName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.stLblEncodingName.MaxWidth = 100;
            this.stLblEncodingName.Name = "stLblEncodingName";
            this.stLblEncodingName.Size = new System.Drawing.Size(100, 24);
            this.stLblEncodingName.Text = "jkl";
            this.stLblEncodingName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rTxtContent
            // 
            this.rTxtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rTxtContent.Location = new System.Drawing.Point(0, 30);
            this.rTxtContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rTxtContent.Name = "rTxtContent";
            this.rTxtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rTxtContent.Size = new System.Drawing.Size(691, 383);
            this.rTxtContent.TabIndex = 1;
            this.rTxtContent.Text = "";
            this.rTxtContent.WordWrap = false;
            this.rTxtContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.rTxtContent_DragDrop);
            this.rTxtContent.DragEnter += new System.Windows.Forms.DragEventHandler(this.rTxtContent_DragEnter);
            this.rTxtContent.SelectionChanged += new System.EventHandler(this.rTxtContent_SelectionChanged);
            this.rTxtContent.TextChanged += new System.EventHandler(this.rTxtContent_TextChanged);
            this.rTxtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rTxtContent_KeyDown);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 443);
            this.Controls.Add(this.rTxtContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "记事本";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem sunNewFile;
        private System.Windows.Forms.ToolStripMenuItem subNewWindow;
        private System.Windows.Forms.ToolStripMenuItem subOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subExit;
        private System.Windows.Forms.ToolStripMenuItem subSaveFile;
        private CustomRichTextBox rTxtContent;
        private System.Windows.Forms.ToolStripMenuItem subSaveAsFile;
        private System.Windows.Forms.ToolStripMenuItem subPagePreview;
        private System.Windows.Forms.ToolStripMenuItem subPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem subUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem subCut;
        private System.Windows.Forms.ToolStripMenuItem subCopy;
        private System.Windows.Forms.ToolStripMenuItem subPaste;
        private System.Windows.Forms.ToolStripMenuItem subDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem subFind;
        private System.Windows.Forms.ToolStripMenuItem subFindNext;
        private System.Windows.Forms.ToolStripMenuItem subFindLast;
        private System.Windows.Forms.ToolStripMenuItem subReplace;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private CustomToolStripStatusLabel stLblFileAttr;
        private CustomToolStripStatusLabel stLblColAndRow;
        private CustomToolStripStatusLabel stLblZoomFactor;
        private CustomToolStripStatusLabel customToolStripStatusLabel4;
        private CustomToolStripStatusLabel stLblEncodingName;
        private System.Windows.Forms.ToolStripMenuItem subGoto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem subSelectAll;
        private System.Windows.Forms.ToolStripMenuItem subInsertDate;
        private System.Windows.Forms.ToolStripMenuItem formatMenu;
        private System.Windows.Forms.ToolStripMenuItem subWordWrop;
        private System.Windows.Forms.ToolStripMenuItem subFont;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem zoomMenu;
        private System.Windows.Forms.ToolStripMenuItem subZoomIn;
        private System.Windows.Forms.ToolStripMenuItem subZoomOut;
        private System.Windows.Forms.ToolStripMenuItem subZoomReset;
        private System.Windows.Forms.ToolStripMenuItem subShowStatus;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送反馈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 关于记事本ToolStripMenuItem;
    }
}

