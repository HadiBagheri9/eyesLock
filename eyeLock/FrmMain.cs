using System;
using System.IO;
using eyeStar_ClassLibrary;
using System.Collections.Generic;
using PersonalClassLibrary.Notif;
using PersonalClassLibrary.Windows;
using System.Windows.Forms;

namespace eyeLock
{
    public partial class FrmMain : FrmTemp
    {
        List<string> listFiles = new List<string>();
        string fileNameAddition = "eye";
        string path;
        bool isCryptionOn = false, isLockingOn = false, isRecoveryFileOn = false;

        public FrmMain()
        {
            if (User.CheckLicense())
            {
                if (!User.CheckExpiration())
                {
                    InitializeComponent();
                    this.SetTheme();
                }
                else
                {
                    eyeMessageContents.LicenseExpired.MessageBoxError();
                    Environment.Exit(0);
                }
            }
            else 
            {
                eyeMessageContents.LicenseInvalid.MessageBoxError();
                Environment.Exit(0);
            }
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DisableComponents();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = diaSelectFolder.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                EnableComponents();
                DisableButtons();
            }

            path = diaSelectFolder.SelectedPath;
            rtxtPath.Text = path;
        }

        private void btnLockEncrypt_Click(object sender, EventArgs e)
        {
            if (isCryptionOn)
            {
                EncryptFiles(path);
            }

            if (isLockingOn)
            {
                LockFolder(path);
            }

            if (isRecoveryFileOn)
            {
                BackUpFile(path);
            }

            "Done".MessageBoxWarning();
        }

        private void btnUnlockDecrypt_Click(object sender, EventArgs e)
        {
            if (isCryptionOn)
            {
                DecryptFiles(path);
            }

            if (isLockingOn)
            {
                UnlockFolder(path);
            }

            "Done".MessageBoxInformation();
        }

        private void eyeLockLogo_Click(object sender, EventArgs e)
        {
            FrmAboutUs frmAboutUs = new FrmAboutUs();
            frmAboutUs.ShowDialog();
        }

        private void chkCryptography_CheckedChanged(object sender, EventArgs e)
        {
            isCryptionOn = chkCryptography.Checked ? true : false;
            CheckAndChangeButtonsAbility();
        }

        private void chkFolderAccessibility_CheckedChanged(object sender, EventArgs e)
        {
            isLockingOn = chkFolderAccessibility.Checked ? true : false;
            CheckAndChangeButtonsAbility();
        }

        private void chkRecoveryFile_CheckedChanged(object sender, EventArgs e)
        {
            isRecoveryFileOn = chkRecoveryFile.Checked ? true : false;
            CheckAndChangeButtonsAbility();
        }

        private void eyeLockLogo_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(eyeLockLogo, "About eyeLock");
        }

        //**********************************************************************

        private void LockFolder(string path)
        {
            try
            {
                FolderOptions.LockDirectory(path);
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError();
            }
        }

        private void UnlockFolder(string path)
        {
            try
            {
                FolderOptions.UnLockDirectory(path);
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError();
            }
        }

        private void EncryptFiles(string path)
        {
            try
            {
                listFiles = FolderOptions.GetAllFiles(path);

                foreach (var item in listFiles)
                {
                    PersonalClassLibrary.Windows.FileOptions.EncryptFile(item, item + fileNameAddition, User._16ByteKey);
                    File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError();
            }
        }

        private void DecryptFiles(string path)
        {
            try
            {
                listFiles = FolderOptions.GetAllFiles(path);

                foreach (var item in listFiles)
                {
                    if (item.EndsWith(fileNameAddition))
                    {
                        PersonalClassLibrary.Windows.FileOptions.DecryptFile(item, item.Remove(item.Length-3, 3), User._16ByteKey);
                        File.Delete(item);
                    }
                    else
                    {
                        PersonalClassLibrary.Windows.FileOptions.DecryptFile(item, item + fileNameAddition, User._16ByteKey);
                        File.Delete(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError();
            }
        }

        private void BackUpFile(string path)
        {
             
        }

        //**********************************************************************

        private void CheckAndChangeButtonsAbility()
        {
            if ((!isCryptionOn) && (!isLockingOn))
            {
                DisableButtons();
            }
            else
            {
                EnableButtons();
            }
        }

        /// <summary>
        /// To disable components
        /// </summary>
        private void DisableComponents()
        {
            chkCryptography.Enabled = false;
            chkFolderAccessibility.Enabled = false;
            chkRecoveryFile.Enabled = false;
            btnLockEncrypt.Enabled = false;
            btnUnlockDecrypt.Enabled = false;
        }

        /// <summary>
        /// To enable components
        /// </summary>
        private void EnableComponents()
        {
            chkCryptography.Enabled = true;
            chkFolderAccessibility.Enabled = true;
            chkRecoveryFile.Enabled = true;
            btnLockEncrypt.Enabled = true;
            btnUnlockDecrypt.Enabled = true;
        }

        /// <summary>
        /// To disable buttons
        /// </summary>
        private void DisableButtons()
        {
            btnLockEncrypt.Enabled = false;
            btnUnlockDecrypt.Enabled = false;
        }

        /// <summary>
        /// To enable buttons
        /// </summary>
        private void EnableButtons()
        {
            btnLockEncrypt.Enabled = true;
            btnUnlockDecrypt.Enabled = true;
        }
    }
}
