using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace eyesLock
{
    class FileOptions
    {
        static string seedPhraseFileFormat = ".eyesph";

        public static List<string> ListSeedPhrases()
        {
            List<string> listFiles = new List<string>();
            string[] arrayFiles = Directory.GetFiles(Application.StartupPath, $"*{seedPhraseFileFormat}");
            foreach (var item in arrayFiles)
            {
                listFiles.Add(item);
            }

            return listFiles;
        }
        public static bool EncryptFile(string inputFilePath, string outputFilePath, string key, byte[] iv)
        {
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        aes.KeySize = 256;
                        aes.Key = Encoding.ASCII.GetBytes(key);
                        aes.IV = iv;

                        // Perform encryption
                        ICryptoTransform encryptor = aes.CreateEncryptor();
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                        {
                            fsInput.CopyTo(cs);
                            return true;
                        }
                    }
                }
            }
        }

        public static bool DecryptFile(string inputFilePath, string outputFilePath, string key, byte[] iv)
        {
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        aes.KeySize = 256;
                        aes.Key = Encoding.ASCII.GetBytes(key);
                        aes.IV = iv;

                        // Perform encryption
                        ICryptoTransform encryptor = aes.CreateDecryptor();
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                        {
                            fsInput.CopyTo(cs);
                            return true;
                        }
                    }
                }
            }
        }
    }
}
