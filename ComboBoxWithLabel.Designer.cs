
namespace WinNotepad
{
    partial class ComboBoxWithLabel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cboList = new System.Windows.Forms.ComboBox();
            this.lblCboName = new System.Windows.Forms.Label();
            this.basePanel = new System.Windows.Forms.Panel();
            this.basePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboList
            // 
            this.cboList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboList.FormattingEnabled = true;
            this.cboList.Location = new System.Drawing.Point(0, 0);
            this.cboList.Name = "cboList";
            this.cboList.Size = new System.Drawing.Size(140, 28);
            this.cboList.TabIndex = 0;
            // 
            // lblCboName
            // 
            this.lblCboName.AutoSize = true;
            this.lblCboName.BackColor = System.Drawing.Color.Transparent;
            this.lblCboName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCboName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCboName.Location = new System.Drawing.Point(0, 0);
            this.lblCboName.Name = "lblCboName";
            this.lblCboName.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblCboName.Size = new System.Drawing.Size(0, 25);
            this.lblCboName.TabIndex = 1;
            // 
            // basePanel
            // 
            this.basePanel.AutoSize = true;
            this.basePanel.Controls.Add(this.cboList);
            this.basePanel.Controls.Add(this.lblCboName);
            this.basePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.basePanel.Location = new System.Drawing.Point(0, 0);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(140, 35);
            this.basePanel.TabIndex = 2;
            this.basePanel.SizeChanged += new System.EventHandler(this.basePanel_SizeChanged);
            // 
            // ComboBoxWithLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.basePanel);
            this.Name = "ComboBoxWithLabel";
            this.Size = new System.Drawing.Size(144, 35);
            this.basePanel.ResumeLayout(false);
            this.basePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboList;
        private System.Windows.Forms.Label lblCboName;
        private System.Windows.Forms.Panel basePanel;
    }
}
