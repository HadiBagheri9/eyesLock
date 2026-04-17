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
            Application.Run(new FrmImportSeed());

            // Get List of the Seed Phrase files to Check.
            List<string> listFiles = FileOptions.ListSeedPhrases();

            // 1 Comments
            //The initial version of the software includes only one seed phrase file.
            //The ability to add more seed phrases will be added soon.
            //If more than one seed phrase file exist, it opens first item of the list.
            if (listFiles.Count > 0)
            {
                //FrmEnterPass frmEnterPass = new FrmEnterPass();
            }
            else
            { 
                //Open FrmImportSeed
            }

            // Only for test
            string testM = "";//1
            foreach (var item in listFiles)//1
            {
                testM += item + "\n";//1
            }
            MessageBox.Show(testM);//1
            
        }
    }
}
