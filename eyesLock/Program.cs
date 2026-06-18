/*
 Copyright (C) 2026 [HadiBagheri9]
 SPDX-License-Identifier: GPL-3.0-only
*/
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
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
                if (!Directory.Exists(Global._IconsSaveAddressFolder))
                {
                    Directory.CreateDirectory(Global._IconsSaveAddressFolder);
                }

                // Set Icon for .eyes encrypted Files
                if (!File.Exists(Global._IconsSaveAddressFolder + Global._EYES_IconSaveFileName))
                {
                    if (!IsAdministrator())
                    {
                        MessageBox.Show("Please run the software as administrator and ensure that your Internet is connected to download icons from Github and initialize file icon settings.", "eyesLock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }

                    FileOptions.LocateIconFile(Global._EYES_IconDownloadAddress, Global._IconsSaveAddressFolder + Global._EYES_IconSaveFileName);
                    FileOptions.SetFileExtensionDefaultIcon(Global._EYES_FileExtension, Global._EYES_IconTypeName,
                    Global._EYES_IconDiscription, Global._IconsSaveAddressFolder + Global._EYES_IconSaveFileName);
                }

                // Set Icon for .eyesph seed phrase Files
                if (!File.Exists(Global._IconsSaveAddressFolder + Global._EYESPH_IconSaveFileName))
                {
                    if (!IsAdministrator())
                    {
                        MessageBox.Show("Please run the software as administrator to initialize file icon settings.", "eyesLock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }

                    FileOptions.LocateIconFile(Global._EYESPH_IconDownloadAddress, Global._IconsSaveAddressFolder + Global._EYESPH_IconSaveFileName);
                    FileOptions.SetFileExtensionDefaultIcon(Global._EYESPH_FileExtension, Global._EYESPH_IconTypeName,
                    Global._EYESPH_IconDiscription, Global._IconsSaveAddressFolder + Global._EYESPH_IconSaveFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Icon file initializing failed :\n{ex.Message}", "eyesLock", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Delete .eyes icon if download operation failed
                if (File.Exists(Global._IconsSaveAddressFolder + Global._EYES_IconSaveFileName))
                {
                    File.Delete(Global._IconsSaveAddressFolder + Global._EYES_IconSaveFileName);
                }

                // Delete .eyesph icon if download operation failed
                if (File.Exists(Global._IconsSaveAddressFolder + Global._EYESPH_IconSaveFileName))
                {
                    File.Delete(Global._IconsSaveAddressFolder + Global._EYESPH_IconSaveFileName);
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
