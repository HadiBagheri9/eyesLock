using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace eyesLock
{
    public partial class FrmMain : FrmTemp
    {
        List<string> listFiles = new List<string>();
        string fileNameAddition = ".eye", recoveryFileName = "recovery.txt";
        string isEncryptionNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIf your data is sensitive and important, you must turn on the recovery file option.\n\nDo you want to turn it on?";
        //string isDecryptionNotRecoveryFileOnMessage = "Recovery file option is not enabaled!\nIt is better to turn on the recovery file option when you want to do Decryption Operation.\nIf you turn it on, it will delete the recovery.info file.";
        string path;
        
        bool isCryptionOn = false, isLockingOn = false, isRecoveryFileOn = false;

        public FrmMain()
        {
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

            
            if (!isRecoveryFileOn)
            {

                DialogResult flag = MessageBox.Show(isEncryptionNotRecoveryFileOnMessage, "eyeLock Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                isRecoveryFileOn = flag == DialogResult.Yes ? true : false;
                chkRecoveryFile.Checked = flag == DialogResult.Yes ? true : false;
            }

            if (isCryptionOn)
            {
                await EncryptFilesAsync(path);
                rtxtPath.Text += "\n\nInfo: Encryption has been done.";
            }
            
            if (isRecoveryFileOn)
            {
                RecoveryFile(path);
                rtxtPath.Text += $"\nInfo: {recoveryFileName} has been made.";
            }

            if (isLockingOn)
            {
                LockFolder(path);
                rtxtPath.Text += "\nInfo: Folder has been locked.";
            }

            EnableButtons();
        }

        private async void btnUnlockDecrypt_Click(object sender, EventArgs e)
        {
            DisableButtons();
            rtxtPath.Clear();
            rtxtPath.Text = path;


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
                rtxtPath.Text += "\nInfo: Folder has been Unlocked";
            }

            if (isCryptionOn)
            {
                await DecryptFilesAsync(path);
                rtxtPath.Text += "\n\nInfo: Decryption has been done.";
            }

            /*
            if (isRecoveryFileOn)
            {
                if (File.Exists($"{path}\\{recoveryFileName}"))
                {
                    try
                    {
                        File.Delete($"{path}\\{recoveryFileName}");
                        rtxtPath.Text += $"\nInfo: {recoveryFileName} has been deleted.";
                    }
                    catch (Exception ex)
                    {
                        rtxtPath.Text+="\nError: " + ex.Message;
                    }
                }
                else
                {
                    rtxtPath.Text += $"\nInfo: {recoveryFileName} was not found!";
                }
            }*/



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
                        Global._FE_Bridge = Key_IV_Generator.HApproach(Global._FE_Base);
                        Global._FE_DK = Key_IV_Generator.HMethod_DK(Global._FE_Bridge);
                        Global._FE_DV = Encoding.ASCII.GetBytes(Key_IV_Generator.HMethod_DV(Global._FE_Bridge)); ;
                        

                        FileOptions.EncryptFile(item, output, Global._FE_DK,Global._FE_DV);
                        File.SetAttributes(output, FileAttributes.ReadOnly);
                        File.Delete(item);
                    });
                    rtxtPath.Text += $"\nEncrypted: {item}";
                    Thread.Sleep(10);


                }
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
                                Global._FE_Bridge = Key_IV_Generator.HApproach(Global._FE_Base);
                                Global._FE_DK = Key_IV_Generator.HMethod_DK(Global._FE_Bridge);
                                Global._FE_DV = Encoding.ASCII.GetBytes(Key_IV_Generator.HMethod_DV(Global._FE_Bridge)); ;
                                

                                FileOptions.DecryptFile(item, output, Global._FE_DK, Global._FE_DV);
                                File.Delete(item);
                            });
                            rtxtPath.Text += $"\nDecrypted: {item}";
                            Thread.Sleep(10);
                        }
                        else
                        {
                            if (item.EndsWith("desktop.ini"))
                            {
                                File.SetAttributes(item, FileAttributes.Hidden);
                                continue;
                            }

                            rtxtPath.Text += $"\nError: {item} is not in a correct format to decrypt!";
                        }
                    }
                    catch (Exception ex)
                    {
                        rtxtPath.Text += "\nError: " + ex.Message;
                        continue;
                    }
                }
                listFiles.Clear();
            }
            catch (Exception ex)
            {
                rtxtPath.Text += "\nError: " + ex.Message;
            }
        }
        
        private void RecoveryFile(string path)
        {
            string recoveryFilePath = string.Format($"{path}\\{recoveryFileName}");
            string[] encryptedFiles = Directory.GetFiles(path);
            StreamWriter streamWriter = new StreamWriter(recoveryFilePath);
            streamWriter.WriteLine("Name\tSize\tCreation Time");

            foreach (var item in encryptedFiles)
            {
                if (item.EndsWith("desktop.ini"))
                {
                    continue;
                }
                FileInfo fileInfo = new FileInfo(item);
                
                try
                {
                    streamWriter.WriteLine($"{fileInfo.Name}\t{fileInfo.Length} Bytes\t{fileInfo.CreationTime}");
                }
                catch (Exception ex)
                {
                    rtxtPath.Text += $"\n{ex.Message}";
                }
            }
            streamWriter.Close();
            streamWriter.Dispose();
        }

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
