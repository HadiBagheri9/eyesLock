using System;
using System.IO;
using eyeStar_ClassLibrary;
using System.Collections.Generic;
using PersonalClassLibrary.Notif;
using PersonalClassLibrary.Windows;
using System.Windows.Forms;
using PersonalClassLibrary.Data;
using System.Threading.Tasks;

namespace eyeLock
{
    public partial class FrmMain : FrmTemp
    {
        List<string> listFiles = new List<string>(), listFolders = new List<string>();
        string fileNameAddition = ".eye", recoveryFileName = "recovery.info", separatorString = "|||";
        string isNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIf your data is sensitive and important, you should turn on the recovery file option.\n\nDo you want to turn it on?";
        string path;
        string cipher = "1385/12/24HadieyeLock";
        
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
                    eyeMessageContents.LicenseExpired.MessageBoxError("eyeLock Error");
                    Environment.Exit(0);
                }
            }
            else 
            {
                eyeMessageContents.LicenseInvalid.MessageBoxError("eyeLock Error");
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

        private async void btnLockEncrypt_Click(object sender, EventArgs e)
        {
            DisableButtons();

            if (!isRecoveryFileOn)
            {

                DialogResult flag = MessageBox.Show(isNotRecoveryFileOnMessage, "eyeLock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isRecoveryFileOn = flag == DialogResult.Yes ? true : false;
            }

            if (isCryptionOn)
            {
                await EncryptFilesAsync(path);
                lblLog.Text = "Encryption has been done.";
            }

            if (isRecoveryFileOn)
            {
                BackUpFile(path);
            }

            if (isLockingOn)
            {
                LockFolder(path);
                lblLog.Text = "Folder has been locked.";
            }


            EnableButtons();
        }

        private async void btnUnlockDecrypt_Click(object sender, EventArgs e)
        {
            DisableButtons();

            string backUpFileName = path + "\\" + recoveryFileName;

            if (File.Exists(backUpFileName))
            {
                try
                {
                    File.Delete(backUpFileName);
                }
                catch (Exception ex)
                {
                    ex.Message.MessageBoxError("eyeLock Error");
                }
            }

            if (isLockingOn)
            {
                UnlockFolder(path);
                lblLog.Text = "Folder has been Unlocked";
            }

            if (isCryptionOn)
            {
                await DecryptFilesAsync(path);
                lblLog.Text = "Decryption has been done.";
            }

            EnableButtons();
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
                //listFolders = FolderOptions.GetAllFolders(path);
                //
                //foreach (var item in listFolders)
                //{
                //    FolderOptions.LockDirectory(item);
                //}

                FolderOptions.LockDirectory(path);
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError("eyeLock Error");
            }
        }

        private void UnlockFolder(string path)
        {
            try
            {
                FolderOptions.UnLockDirectory(path);
                //listFolders = FolderOptions.GetAllFolders(path);
                //
                //foreach (var item in listFolders)
                //{
                //    FolderOptions.UnLockDirectory(item);
                //}
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError("eyeLock Error");
            }
        }

        private async Task EncryptFilesAsync(string path)
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

                    await Task.Run(() =>
                    {
                        PersonalClassLibrary.Windows.FileOptions.EncryptFile(item, output, User._16ByteKey, new byte[16]);
                        File.SetAttributes(output, FileAttributes.ReadOnly);
                        File.Delete(item);
                        
                    });
                    rtxtPath.Text += $"\nWorking: {item}";

                    //if ((item + fileNameAddition).EndsWith("desktop.ini" + fileNameAddition))
                    //    File.SetAttributes((item + fileNameAddition), FileAttributes.Hidden);


                }
                foreach (var item in listFiles)
                {
                    rtxtPath.Text += $"\nEncrypted: {item}";
                }
                listFiles.Clear();
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError("eyeLock Error");
            }
        }

        private async Task DecryptFilesAsync(string path)
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
                            await Task.Run(() =>
                            {
                                PersonalClassLibrary.Windows.FileOptions.DecryptFile(item, output, User._16ByteKey, new byte[16]);
                                File.Delete(item);
                            });
                            rtxtPath.Text += $"\nWorking: {output}";
                            //if ((item.Remove(item.Length - fileNameAddition.Length, fileNameAddition.Length)).EndsWith("desktop.ini"))
                            //    File.SetAttributes((item.Remove(item.Length - fileNameAddition.Length, fileNameAddition.Length)), FileAttributes.Hidden);


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
                        ex.Message.MessageBoxError("eyeLock Error");
                        continue;
                    }
                }
                foreach (var item in listFiles)
                {
                    rtxtPath.Text += $"\nDecrypted: {item}";
                }
                listFiles.Clear();
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError("eyeLock Error");
            }
        }
           
        private void BackUpFile(string path)
        {
            string salt;
            string backUpFileName = path + "\\" + recoveryFileName;

            try
            {
                string content = string.Format($"{User._LicenseKey}{separatorString}{User._16ByteKey}{separatorString}" +
                $"{User.__User}{separatorString}{User.__Pass}{separatorString}{User.__Insta}{separatorString}" +
                $"{User.__Disc}{separatorString}{User.__PaidA}");
                foreach (var item in listFiles)
                {
                    content += string.Format($"\n{item}");
                }

                salt = eyeKeyMethods.HApproach(eyeKeyMethods.HMethod(cipher));
                salt = salt.Remove(salt.Length - 2, 2);
                salt += salt;
                //salt += salt;
                salt = salt.ReverseText();
                salt = salt.Replace('r', '&');

                content = CryptText.Encrypt(content, salt, new byte[16]);
                File.WriteAllText(backUpFileName, content);
            }
            catch (Exception ex)
            {
                ex.Message.MessageBoxError("eyeLock Error");
            }
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
