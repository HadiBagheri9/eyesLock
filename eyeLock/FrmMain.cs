using System;
using System.IO;
using eyeStar_ClassLibrary;
using System.Collections.Generic;
using PersonalClassLibrary.Notif;
using PersonalClassLibrary.Windows;
using System.Windows.Forms;
using PersonalClassLibrary.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace eyeLock
{
    public partial class FrmMain : FrmTemp
    {
        List<string> listFiles = new List<string>(), listFolders = new List<string>();
        string fileNameAddition = ".eye";//,
            //recoveryFileName = "recovery.info",
            //separatorString = "|||"; // Used in RFCE
        //string isEncryptionNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIf your data is sensitive and important, you should turn on the recovery file option.\n\nDo you want to turn it on?";
        //string isDecryptionNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIt is better to turn on the recovery file option when you want to do Decryption Operation.\nIf you turn it on, it will delete the recovery.info file.";
        //string RFCE_Base = "eyeLock"; // Base
        string path;
        
        bool isCryptionOn = false, isLockingOn = false, isRecoveryFileOn = false;

        public FrmMain()
        {
            /*
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
            */
            InitializeComponent();
            this.SetTheme();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            DisableComponents();

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLockEncrypt, "Encrypt | Lock");
            toolTip.SetToolTip(btnUnlockDecrypt, "Decrypt | Unlock");
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
            rtxtPath.Clear();
            rtxtPath.Text = path;

            /*
            if (!isRecoveryFileOn)
            {

                DialogResult flag = MessageBox.Show(isEncryptionNotRecoveryFileOnMessage, "eyeLock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isRecoveryFileOn = flag == DialogResult.Yes ? true : false;
                chkRecoveryFile.Checked = flag == DialogResult.Yes ? true : false;
            }*/

            if (isCryptionOn)
            {
                await EncryptFilesAsync(path);
                rtxtPath.Text += "\n\nInfo: Encryption has been done.";
            }
            /*
            if (isRecoveryFileOn)
            {
                BackUpFile(path);
                rtxtPath.Text += "\nInfo: recovery.info has been made.";
            }*/

            if (isLockingOn)
            {
                LockFolder(path);
                rtxtPath.Text += "\nInfo: Folder has been locked.";
            }

            //rtxtPath.Text += "\n\n\nInfo: All Done!";
            EnableButtons();
        }

        private async void btnUnlockDecrypt_Click(object sender, EventArgs e)
        {
            DisableButtons();
            rtxtPath.Clear();
            rtxtPath.Text = path;

            //string backUpFileName = path + "\\" + recoveryFileName;

            /*
            if (!isRecoveryFileOn)
            {

                DialogResult flag = MessageBox.Show(isDecryptionNotRecoveryFileOnMessage, "eyeLock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isRecoveryFileOn = flag == DialogResult.Yes ? true : false;
                chkRecoveryFile.Checked = flag == DialogResult.Yes ? true : false;
            }*/

            if (isLockingOn)
            {
                UnlockFolder(path);
                //lblLog.Text = "Folder has been Unlocked";
                rtxtPath.Text += "\nInfo: Folder has been Unlocked";
            }

            if (isCryptionOn)
            {
                await DecryptFilesAsync(path);
                //lblLog.Text = "Decryption has been done.";
                rtxtPath.Text += "\n\nInfo: Decryption has been done.";
            }

            /*
            if (isRecoveryFileOn)
            {
                if (File.Exists(backUpFileName))
                {
                    try
                    {
                        File.Delete(backUpFileName);
                        rtxtPath.Text += "\nInfo: recovery.info has been deleted.";
                    }
                    catch (Exception ex)
                    {
                        rtxtPath.Text+="\nError: " + ex.Message;
                    }
                }
                else
                {
                    rtxtPath.Text += "\nInfo: recovery.info was not found!";
                }
            }*/



            //rtxtPath.Text += "\n\n\nInfo: All Done!";
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
                 rtxtPath.Text += "\nError: " + ex.Message;
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
                 rtxtPath.Text += "\nError: " + ex.Message;
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

                    rtxtPath.Text += $"\nWorking: {item}";
                    await Task.Run(() =>
                    {
                        FileInfo fileInfo = new FileInfo(output);
                        Global._FE_Base = $"{Global._SeedPhrase}{fileInfo.Name}";
                        Global._FE_Bridge = eye_Key_IV.HApproach(Global._FE_Base);
                        Global._FE_DK = eye_Key_IV.HMethod_DK(Global._FE_Bridge);
                        Global._FE_DV = Encoding.ASCII.GetBytes(eye_Key_IV.HMethod_DV(Global._FE_Bridge)); ;
                        MessageBox.Show($"{Global._FE_DK}\n{eye_Key_IV.HMethod_DV(Global._FE_Bridge)}\n{Global._FE_DV.Length.ToString()}");//1

                        PersonalClassLibrary.Windows.FileOptions.EncryptFile(item, output, Global._FE_DK,Global._FE_DV);
                        File.SetAttributes(output, FileAttributes.ReadOnly);
                        File.Delete(item);
                        //rtxtPath.Text += $"\nEncrypted: {item}";
                    });
                    rtxtPath.Text += $"\nEncrypted: {item}";
                    Thread.Sleep(10);
                    //if ((item + fileNameAddition).EndsWith("desktop.ini" + fileNameAddition))
                    //    File.SetAttributes((item + fileNameAddition), FileAttributes.Hidden);


                }
                //foreach (var item in listFiles)
                //{
                //    rtxtPath.Text += $"\nEncrypted: {item}";
                //}
                listFiles.Clear();
            }
            catch (Exception ex)
            {
                rtxtPath.Text += "\nError: " + ex;
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
                            rtxtPath.Text += $"\nWorking: {item}";
                            await Task.Run(() =>
                            {
                                FileInfo fileInfo = new FileInfo(item);
                                Global._FE_Base = $"{Global._SeedPhrase}{fileInfo.Name}";
                                Global._FE_Bridge = eye_Key_IV.HApproach(Global._FE_Base);
                                Global._FE_DK = eye_Key_IV.HMethod_DK(Global._FE_Bridge);
                                Global._FE_DV = Encoding.ASCII.GetBytes(eye_Key_IV.HMethod_DV(Global._FE_Bridge)); ;
                                MessageBox.Show($"{Global._FE_DK}\n{eye_Key_IV.HMethod_DV(Global._FE_Bridge)}\n{Global._FE_DV.Length.ToString()}");//1

                                PersonalClassLibrary.Windows.FileOptions.DecryptFile(item, output, Global._FE_DK, Global._FE_DV);
                                File.Delete(item);
                            });
                            rtxtPath.Text += $"\nDecrypted: {item}";
                            Thread.Sleep(10);
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

                            rtxtPath.Text += $"\nError: {item} is not in a correct format to decrypt!";
                            //File.Delete(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        rtxtPath.Text += "\nError: " + ex.Message;
                        continue;
                    }
                }
                //foreach (var item in listFiles)
                //{
                //    rtxtPath.Text += $"\nDecrypted: {item}";
                //}
                listFiles.Clear();
            }
            catch (Exception ex)
            {
                rtxtPath.Text += "\nError: " + ex.Message;
            }
        }
        /*
        private void BackUpFile(string path)
        {
            string RFCE_DK;
            string backUpFileName = path + "\\" + recoveryFileName;

            try
            {
                string content = string.Format($"{User._LicenseKey}{separatorString}{User._FE_DK}{separatorString}" +
                $"{User.__User}{separatorString}{User.__Pass}{separatorString}{User.__Insta}{separatorString}" +
                $"{User.__Disc}{separatorString}{User.__PaidA}");
                foreach (var item in listFiles)
                {
                    content += string.Format($"\n{item}");
                }

                RFCE_DK = eye_Key_IV.HMethod_DK(eye_Key_IV.HApproach(RFCE_Base));
                RFCE_DK = RFCE_DK.Remove(RFCE_DK.Length - 2, 2);
                RFCE_DK += RFCE_DK;
                //salt += salt;
                RFCE_DK = RFCE_DK.ReverseText();
                RFCE_DK = RFCE_DK.Replace('r', '&');

                content = CryptText.Encrypt(content, RFCE_DK, new byte[16]);
                File.WriteAllText(backUpFileName, content);
            }
            catch (Exception ex)
            {
                rtxtPath.Text += "\nError: " + ex.Message;
            }
        }*/

        //**********************************************************************

        /// <summary>
        /// If checkboxes are not checked buttons will be disabled
        /// </summary>
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
