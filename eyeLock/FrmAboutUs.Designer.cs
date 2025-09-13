
namespace eyeLock
{
    partial class FrmAboutUs
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
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.eyeStarLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eyeLockLogo = new System.Windows.Forms.PictureBox();
            this.pnlSideBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeStarLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLockLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSideBar.Controls.Add(this.btnClose);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 844);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(488, 104);
            this.pnlSideBar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(41)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnClose.Location = new System.Drawing.Point(177, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 54);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lbl3);
            this.pnlMain.Controls.Add(this.lbl2);
            this.pnlMain.Controls.Add(this.lbl);
            this.pnlMain.Controls.Add(this.eyeStarLogo);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.eyeLockLogo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(488, 844);
            this.pnlMain.TabIndex = 1;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(42, 550);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 25);
            this.lbl3.TabIndex = 5;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(37, 257);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 25);
            this.lbl2.TabIndex = 4;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(33, 46);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 24);
            this.lbl.TabIndex = 3;
            // 
            // eyeStarLogo
            // 
            this.eyeStarLogo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.eyeStarLogo.Image = global::eyeLock.Properties.Resources.eyeStar_logo_5th_reshape;
            this.eyeStarLogo.Location = new System.Drawing.Point(376, 530);
            this.eyeStarLogo.Name = "eyeStarLogo";
            this.eyeStarLogo.Size = new System.Drawing.Size(72, 72);
            this.eyeStarLogo.TabIndex = 2;
            this.eyeStarLogo.TabStop = false;
            this.eyeStarLogo.MouseHover += new System.EventHandler(this.eyeStarLogo_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "About Us";
            // 
            // eyeLockLogo
            // 
            this.eyeLockLogo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.eyeLockLogo.Image = global::eyeLock.Properties.Resources._12;
            this.eyeLockLogo.Location = new System.Drawing.Point(276, 46);
            this.eyeLockLogo.Margin = new System.Windows.Forms.Padding(3, 20, 20, 3);
            this.eyeLockLogo.Name = "eyeLockLogo";
            this.eyeLockLogo.Size = new System.Drawing.Size(172, 172);
            this.eyeLockLogo.TabIndex = 0;
            this.eyeLockLogo.TabStop = false;
            this.eyeLockLogo.MouseHover += new System.EventHandler(this.eyeLockLogo_MouseHover);
            // 
            // FrmAboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(488, 948);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSideBar);
            this.Name = "FrmAboutUs";
            this.Load += new System.EventHandler(this.FrmAboutUs_Load);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeStarLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLockLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox eyeLockLogo;
        private System.Windows.Forms.PictureBox eyeStarLogo;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
    }
}