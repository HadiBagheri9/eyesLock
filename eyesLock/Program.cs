using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Security.Principal;

namespace eyesLock
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Basic Start Operation.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //);

            // Initializing icon settings.
            try
            {
                if (!Directory.Exists(Global._IconSaveAddressFolder) || !File.Exists(Global._IconSaveAddressFolder + Global._IconSaveFileName))
                {
                    if (!IsAdministrator())
                    {
                        MessageBox.Show("Please run the software as administrator to initialize file icon settings.", "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }
                    Directory.CreateDirectory(Global._IconSaveAddressFolder);
                    FileOptions.LocateIconFile(Global._IconDownloadAddress, Global._IconSaveAddressFolder + Global._IconSaveFileName);
                    FileOptions.SetFileExtensionDefaultIcon(Global._EncryptedFileExtension, Global._EncryptedFileTypeName,
                    Global._EncryptedFileTypeDiscription, Global._IconSaveAddressFolder + Global._IconSaveFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Icon file initializing failed :\n{ex.Message}", "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (File.Exists(Global._IconSaveAddressFolder + Global._IconSaveFileName))
                {
                    File.Delete(Global._IconSaveAddressFolder + Global._IconSaveFileName);
                }
            }
            

            // Get List of the Seed Phrase files to Check.
            List<string> listFiles = FileOptions.ListSeedPhraseFiles();

            // 1 Comments
            //The initial version of the software includes only one seed phrase file.
            //The ability to add more seed phrases will be added soon.
            //If more than one seed phrase file exist, it opens first item of the list.
            if (listFiles.Count > 0)
            {
                Application.Run(new FrmPassword(FrmPasswordType.Enter));
            }
            else
            {
                Application.Run(new FrmImportSeed());
            }
        }
        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
