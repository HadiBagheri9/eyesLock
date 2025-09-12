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
        string fileNameAddition = ".eye", isNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIf your data is sensitive and important, you should turn on the recovery file option.\n\nDo you want to turn it on?";
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
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLockEncrypt, "Lock | Encrypt");
            toolTip.SetToolTip(btnUnlockDecrypt, "Unlock | Decrypt");
            toolTip.SetToolTip(btnSelectFolder, "Select a folder.");
            toolTip.SetToolTip(chkCryptography, "Enable : It does the cryptography operation for files within the folder.");
            toolTip.SetToolTip(chkFolderAccessibility, "Enable : It does the folder access limiting operation for the top folder.");
            toolTip.SetToolTip(chkRecoveryFile, "Enable : It creates a recovery file next to the selected folder. It is efficient for sensitive data.");
            toolTip.SetToolTip(eyeLockLogo, "About eyeLock");
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
            if (!isRecoveryFileOn)
            {

                DialogResult flag = MessageBox.Show(isNotRecoveryFileOnMessage, "eyeLock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isRecoveryFileOn = flag == DialogResult.Yes ? true : false;
            }

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
                    string output = item + fileNameAddition;

                    if (item.EndsWith("desktop.ini"))
                    {
                        File.SetAttributes(item, FileAttributes.Hidden);
                        continue;
                    }

                    PersonalClassLibrary.Windows.FileOptions.EncryptFile(item, output, User._16ByteKey);
                    File.SetAttributes(output, FileAttributes.ReadOnly);

                    //if ((item + fileNameAddition).EndsWith("desktop.ini" + fileNameAddition))
                    //    File.SetAttributes((item + fileNameAddition), FileAttributes.Hidden);

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
                    string output = item.Remove(item.Length - fileNameAddition.Length, fileNameAddition.Length);

                    try
                    {
                        if (item.EndsWith(fileNameAddition))
                        {
                            File.SetAttributes(item, ~FileAttributes.ReadOnly);
                            PersonalClassLibrary.Windows.FileOptions.DecryptFile(item, output, User._16ByteKey);

                            //if ((item.Remove(item.Length - fileNameAddition.Length, fileNameAddition.Length)).EndsWith("desktop.ini"))
                            //    File.SetAttributes((item.Remove(item.Length - fileNameAddition.Length, fileNameAddition.Length)), FileAttributes.Hidden);

                            File.Delete(item);
                        }
                        else
                        {
                            if (item.EndsWith("desktop.ini"))
                            {
                                File.SetAttributes(item, FileAttributes.Hidden);
                                continue;
                            }

                            $"{item} is not in a correct format to decrypt!".MessageBoxError();
                            //File.Delete(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Message.MessageBoxError();
                        continue;
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
