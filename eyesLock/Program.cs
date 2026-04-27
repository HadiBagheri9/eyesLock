using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;

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

            // Get List of the Seed Phrase files to Check.
            List<string> listFiles = FileOptions.ListSeedPhrases();

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
    }
}
