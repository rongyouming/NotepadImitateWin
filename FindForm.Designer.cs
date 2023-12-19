
namespace WinNotepad
{
    partial class FindForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindContent = new System.Windows.Forms.TextBox();
            this.ckbMatchCase = new System.Windows.Forms.CheckBox();
            this.ckbCycle = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtDirDown = new System.Windows.Forms.RadioButton();
            this.rbtDirUp = new System.Windows.Forms.RadioButton();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找内容(N):";
            // 
            // txtFindContent
            // 
            this.txtFindContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFindContent.Location = new System.Drawing.Point(111, 19);
            this.txtFindContent.Name = "txtFindContent";
            this.txtFindContent.Size = new System.Drawing.Size(287, 27);
            this.txtFindContent.TabIndex = 1;
            // 
            // ckbMatchCase
            // 
            this.ckbMatchCase.AutoSize = true;
            this.ckbMatchCase.Checked = true;
            this.ckbMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMatchCase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbMatchCase.Location = new System.Drawing.Point(13, 98);
            this.ckbMatchCase.Name = "ckbMatchCase";
            this.ckbMatchCase.Size = new System.Drawing.Size(126, 24);
            this.ckbMatchCase.TabIndex = 2;
            this.ckbMatchCase.Text = "区分大小写(C)";
            this.ckbMatchCase.UseVisualStyleBackColor = true;
            // 
            // ckbCycle
            // 
            this.ckbCycle.AutoSize = true;
            this.ckbCycle.Checked = true;
            this.ckbCycle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCycle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckbCycle.Location = new System.Drawing.Point(13, 141);
            this.ckbCycle.Name = "ckbCycle";
            this.ckbCycle.Size = new System.Drawing.Size(81, 24);
            this.ckbCycle.TabIndex = 3;
            this.ckbCycle.Text = "循环(R)";
            this.ckbCycle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtDirDown);
            this.groupBox1.Controls.Add(this.rbtDirUp);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(225, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 61);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方向";
            // 
            // rbtDirDown
            // 
            this.rbtDirDown.AutoSize = true;
            this.rbtDirDown.Checked = true;
            this.rbtDirDown.Location = new System.Drawing.Point(93, 28);
            this.rbtDirDown.Name = "rbtDirDown";
            this.rbtDirDown.Size = new System.Drawing.Size(81, 24);
            this.rbtDirDown.TabIndex = 1;
            this.rbtDirDown.TabStop = true;
            this.rbtDirDown.Text = "向下(D)";
            this.rbtDirDown.UseVisualStyleBackColor = true;
            // 
            // rbtDirUp
            // 
            this.rbtDirUp.AutoSize = true;
            this.rbtDirUp.Location = new System.Drawing.Point(6, 28);
            this.rbtDirUp.Name = "rbtDirUp";
            this.rbtDirUp.Size = new System.Drawing.Size(81, 24);
            this.rbtDirUp.TabIndex = 0;
            this.rbtDirUp.Text = "向上(U)";
            this.rbtDirUp.UseVisualStyleBackColor = true;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindNext.Location = new System.Drawing.Point(417, 16);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(114, 33);
            this.btnFindNext.TabIndex = 5;
            this.btnFindNext.Text = "查找下一个(F)";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(417, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbCycle);
            this.Controls.Add(this.ckbMatchCase);
            this.Controls.Add(this.txtFindContent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "查找";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindForm_FormClosed);
            this.Load += new System.EventHandler(this.FindForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindContent;
        private System.Windows.Forms.CheckBox ckbMatchCase;
        private System.Windows.Forms.CheckBox ckbCycle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtDirDown;
        private System.Windows.Forms.RadioButton rbtDirUp;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnCancel;
    }
}