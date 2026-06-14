
namespace eyesLock
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.picShowSeed = new System.Windows.Forms.PictureBox();
            this.btnUnlockDecrypt = new System.Windows.Forms.Button();
            this.btnLockEncrypt = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.eyeLockLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRecoveryFile = new System.Windows.Forms.CheckBox();
            this.chkFolderAccessibility = new System.Windows.Forms.CheckBox();
            this.chkCryptography = new System.Windows.Forms.CheckBox();
            this.rtxtPath = new System.Windows.Forms.RichTextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.diaSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowSeed)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLockLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSideBar.Controls.Add(this.picShowSeed);
            this.pnlSideBar.Controls.Add(this.btnUnlockDecrypt);
            this.pnlSideBar.Controls.Add(this.btnLockEncrypt);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 476);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(488, 104);
            this.pnlSideBar.TabIndex = 0;
            // 
            // picShowSeed
            // 
            this.picShowSeed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowSeed.Location = new System.Drawing.Point(211, 19);
            this.picShowSeed.Name = "picShowSeed";
            this.picShowSeed.Size = new System.Drawing.Size(64, 64);
            this.picShowSeed.TabIndex = 1;
            this.picShowSeed.TabStop = false;
            this.picShowSeed.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnUnlockDecrypt
            // 
            this.btnUnlockDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(123)))), ((int)(((byte)(193)))));
            this.btnUnlockDecrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnlockDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlockDecrypt.Location = new System.Drawing.Point(33, 24);
            this.btnUnlockDecrypt.Name = "btnUnlockDecrypt";
            this.btnUnlockDecrypt.Size = new System.Drawing.Size(132, 54);
            this.btnUnlockDecrypt.TabIndex = 0;
            this.btnUnlockDecrypt.Text = "Decrypt|U";
            this.btnUnlockDecrypt.UseVisualStyleBackColor = false;
            this.btnUnlockDecrypt.Click += new System.EventHandler(this.btnUnlockDecrypt_Click);
            // 
            // btnLockEncrypt
            // 
            this.btnLockEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(82)))), ((int)(((byte)(164)))));
            this.btnLockEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockEncrypt.Location = new System.Drawing.Point(322, 24);
            this.btnLockEncrypt.Name = "btnLockEncrypt";
            this.btnLockEncrypt.Size = new System.Drawing.Size(132, 54);
            this.btnLockEncrypt.TabIndex = 0;
            this.btnLockEncrypt.Text = "Encrypt|L";
            this.btnLockEncrypt.UseVisualStyleBackColor = false;
            this.btnLockEncrypt.Click += new System.EventHandler(this.btnLockEncrypt_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblLog);
            this.pnlMain.Controls.Add(this.eyeLockLogo);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.chkRecoveryFile);
            this.pnlMain.Controls.Add(this.chkFolderAccessibility);
            this.pnlMain.Controls.Add(this.chkCryptography);
            this.pnlMain.Controls.Add(this.rtxtPath);
            this.pnlMain.Controls.Add(this.btnSelectFolder);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(488, 476);
            this.pnlMain.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(82)))), ((int)(((byte)(164)))));
            this.lblLog.Location = new System.Drawing.Point(33, 289);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(0, 20);
            this.lblLog.TabIndex = 5;
            // 
            // eyeLockLogo
            // 
            this.eyeLockLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyeLockLogo.Image = global::eyesLock.Properties.Resources.eyesLock_Logo_main_172px;
            this.eyeLockLogo.Location = new System.Drawing.Point(282, 289);
            this.eyeLockLogo.Name = "eyeLockLogo";
            this.eyeLockLogo.Size = new System.Drawing.Size(172, 172);
            this.eyeLockLogo.TabIndex = 4;
            this.eyeLockLogo.TabStop = false;
            this.eyeLockLogo.Click += new System.EventHandler(this.eyeLockLogo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "eyesLock";
            // 
            // chkRecoveryFile
            // 
            this.chkRecoveryFile.AutoSize = true;
            this.chkRecoveryFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRecoveryFile.Enabled = false;
            this.chkRecoveryFile.Location = new System.Drawing.Point(33, 409);
            this.chkRecoveryFile.Name = "chkRecoveryFile";
            this.chkRecoveryFile.Size = new System.Drawing.Size(233, 29);
            this.chkRecoveryFile.TabIndex = 2;
            this.chkRecoveryFile.Text = "Create Recovery File";
            this.chkRecoveryFile.UseVisualStyleBackColor = true;
            this.chkRecoveryFile.CheckedChanged += new System.EventHandler(this.chkRecoveryFile_CheckedChanged);
            // 
            // chkFolderAccessibility
            // 
            this.chkFolderAccessibility.AutoSize = true;
            this.chkFolderAccessibility.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFolderAccessibility.Enabled = false;
            this.chkFolderAccessibility.Location = new System.Drawing.Point(33, 362);
            this.chkFolderAccessibility.Name = "chkFolderAccessibility";
            this.chkFolderAccessibility.Size = new System.Drawing.Size(217, 29);
            this.chkFolderAccessibility.TabIndex = 2;
            this.chkFolderAccessibility.Text = "Folder Accessibility";
            this.chkFolderAccessibility.UseVisualStyleBackColor = true;
            this.chkFolderAccessibility.CheckedChanged += new System.EventHandler(this.chkFolderAccessibility_CheckedChanged);
            // 
            // chkCryptography
            // 
            this.chkCryptography.AutoSize = true;
            this.chkCryptography.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCryptography.Location = new System.Drawing.Point(33, 317);
            this.chkCryptography.Name = "chkCryptography";
            this.chkCryptography.Size = new System.Drawing.Size(160, 29);
            this.chkCryptography.TabIndex = 2;
            this.chkCryptography.Text = "Cryptography";
            this.chkCryptography.UseVisualStyleBackColor = true;
            this.chkCryptography.CheckedChanged += new System.EventHandler(this.chkCryptography_CheckedChanged);
            // 
            // rtxtPath
            // 
            this.rtxtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPath.Location = new System.Drawing.Point(33, 159);
            this.rtxtPath.Name = "rtxtPath";
            this.rtxtPath.ReadOnly = true;
            this.rtxtPath.Size = new System.Drawing.Size(421, 118);
            this.rtxtPath.TabIndex = 1;
            this.rtxtPath.Text = "";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(41)))));
            this.btnSelectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnSelectFolder.Location = new System.Drawing.Point(33, 46);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(421, 83);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(488, 580);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSideBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = " eyesLock";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShowSeed)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLockLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Button btnUnlockDecrypt;
        private System.Windows.Forms.Button btnLockEncrypt;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRecoveryFile;
        private System.Windows.Forms.CheckBox chkFolderAccessibility;
        private System.Windows.Forms.CheckBox chkCryptography;
        private System.Windows.Forms.RichTextBox rtxtPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog diaSelectFolder;
        private System.Windows.Forms.PictureBox eyeLockLogo;
        private System.Windows.Forms.Label lblLog;
        public System.Windows.Forms.PictureBox picShowSeed;
    }
}