using System;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Net.Http;

namespace eyesLock
{
    static partial class FileOptions
    {
        /// <summary>
        /// Get list of the existed Seed Phrase files in startup path and return file paths as a list.
        /// </summary>
        /// <returns></returns>
        public static List<string> ListSeedPhraseFiles()
        {
            List<string> listFiles = new List<string>();
            string[] arrayFiles = Directory.GetFiles(Application.StartupPath, $"*{Global._EYESPH_FileExtension}");
            foreach (var item in arrayFiles)
            {
                listFiles.Add(item);
            }

            return listFiles;
        }

        /// <summary>
        /// Get 12 Seed Phrases and return them as a String Array
        /// </summary>
        /// <param name="seedPhraseVariable"></param>
        /// <param name="seedPhraseContent"></param>
        /// <returns></returns>
        public static string[] Get12SeedPhrases(this string[] seedPhraseVariable, string seedPhraseContent)
        {
            string[] getContents = seedPhraseContent.Split(Global._SeedPhraseSeparator);

            for (int i = 0; i < seedPhraseVariable.Length; i++)
            {
                seedPhraseVariable[i] = getContents[i].Trim();
            }
            return seedPhraseVariable;
        }

        /// <summary>
        /// Get the 13th Seed Phrase and return it as a String Variable
        /// </summary>
        /// <param name="seedPhraseVariable"></param>
        /// <param name="seedPhraseContent"></param>
        /// <returns></returns>
        public static string Get13thSeedPhrase(this string seedPhraseVariable, string seedPhraseContent)
        {
            seedPhraseVariable = "";
            string[] getContents = seedPhraseContent.Split(Global._SeedPhraseSeparator);

            if (getContents.Length > 12)
            {
                for (int i = 12; i < getContents.Length; i++)
                {
                    seedPhraseVariable += getContents[i];
                }
            }

            return seedPhraseVariable.Trim();
        }

        
        [DllImport("shell32.dll")]
        static extern void SHChangeNotify(int wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        /// <summary>
        /// Set file icon for a specific file format.
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="fileTypeName"></param>
        /// <param name="description"></param>
        /// <param name="iconPath"></param>
        public static void SetFileExtensionDefaultIcon(
        string extension,
        string fileTypeName,
        string description,
        string iconPath)
        {
            try
            {

                using (RegistryKey extKey = Registry.ClassesRoot.CreateSubKey(extension))
                {
                    extKey.SetValue("", fileTypeName);
                }


                using (RegistryKey typeKey = Registry.ClassesRoot.CreateSubKey(fileTypeName))
                {
                    typeKey.SetValue("", description);

                    using (RegistryKey iconKey = typeKey.CreateSubKey("DefaultIcon"))
                    {
                        iconKey.SetValue("", iconPath);
                    }
                }


                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero); // SHCNE_ASSOCCHANGED

            }
            catch (Exception ex)
            {
                MessageBox.Show($"File Icon Setting Error : \n{ex.Message}", "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LocateIconFile(string downloadAddress, string saveAddress)
        {
            //using (WebClient client = new WebClient())
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //client.DownloadFileTaskAsync(new Uri(downloadAddress), saveAddress);
                    
                    byte[] fileBytes = client.GetByteArrayAsync(downloadAddress).Result; // استفاده از Result برای اجرای همزمان
                    File.WriteAllBytes(saveAddress, fileBytes);

                    if (!File.Exists(saveAddress) || new FileInfo(saveAddress).Length == 0)
                    {
                        throw new Exception("Icon file is not downloaded or it is empty.");
                    }
                }
                catch (WebException ex)
                {
                    throw new Exception($"Error downloading icon from GitHub: {ex.Message}");
                }
            }
        }
    }
}
