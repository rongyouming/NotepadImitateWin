
namespace WinNotepad
{
    partial class ReplaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtReplaceContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFindContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckbCycle = new System.Windows.Forms.CheckBox();
            this.ckbMatchCase = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtReplaceContent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFindContent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 107);
            this.panel1.TabIndex = 0;
            // 
            // txtReplaceContent
            // 
            this.txtReplaceContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReplaceContent.Location = new System.Drawing.Point(112, 56);
            this.txtReplaceContent.Name = "txtReplaceContent";
            this.txtReplaceContent.Size = new System.Drawing.Size(250, 27);
            this.txtReplaceContent.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "替换为(P):";
            // 
            // txtFindContent
            // 
            this.txtFindContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFindContent.Location = new System.Drawing.Point(112, 11);
            this.txtFindContent.Name = "txtFindContent";
            this.txtFindContent.Size = new System.Drawing.Size(250, 27);
            this.txtFindContent.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "查找内容(N):";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckbCycle);
            this.panel2.Controls.Add(this.ckbMatchCase);
            this.panel2.Location = new System.Drawing.Point(2, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 88);
            this.panel2.TabIndex = 1;
            // 
            // ckbCycle
            // 
            this.ckbCycle.AutoSize = true;
            this.ckbCycle.Checked = true;
            this.ckbCycle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCycle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbCycle.Location = new System.Drawing.Point(6, 54);
            this.ckbCycle.Name = "ckbCycle";
            this.ckbCycle.Size = new System.Drawing.Size(81, 24);
            this.ckbCycle.TabIndex = 5;
            this.ckbCycle.Text = "循环(R)";
            this.ckbCycle.UseVisualStyleBackColor = true;
            // 
            // ckbMatchCase
            // 
            this.ckbMatchCase.AutoSize = true;
            this.ckbMatchCase.Checked = true;
            this.ckbMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMatchCase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbMatchCase.Location = new System.Drawing.Point(6, 11);
            this.ckbMatchCase.Name = "ckbMatchCase";
            this.ckbMatchCase.Size = new System.Drawing.Size(126, 24);
            this.ckbMatchCase.TabIndex = 4;
            this.ckbMatchCase.Text = "区分大小写(C)";
            this.ckbMatchCase.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReplace);
            this.panel3.Controls.Add(this.btnReplaceAll);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnFindNext);
            this.panel3.Location = new System.Drawing.Point(383, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(114, 214);
            this.panel3.TabIndex = 2;
            // 
            // btnReplace
            // 
            this.btnReplace.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReplace.Location = new System.Drawing.Point(0, 50);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(114, 33);
            this.btnReplace.TabIndex = 10;
            this.btnReplace.Text = "替换(R)";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReplaceAll.Location = new System.Drawing.Point(0, 95);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(114, 33);
            this.btnReplaceAll.TabIndex = 9;
            this.btnReplaceAll.Text = "全部替换(A)";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(0, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindNext.Location = new System.Drawing.Point(0, 5);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(114, 33);
            this.btnFindNext.TabIndex = 7;
            this.btnFindNext.Text = "查找下一个(F)";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 231);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "替换";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReplaceForm_FormClosed);
            this.Load += new System.EventHandler(this.ReplaceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtReplaceContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFindContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbCycle;
        private System.Windows.Forms.CheckBox ckbMatchCase;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFindNext;
    }
}