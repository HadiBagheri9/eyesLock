using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace eyesLock
{
    partial class FileOptions
    {
        /// <summary>
        /// Encrypt a file using AES256 algorithm.
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static bool EncryptFile(string inputFilePath, string outputFilePath, string key, byte[] iv)
        {
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        aes.Mode = CipherMode.CBC;
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

        /// <summary>
        /// Dencrypt a file using AES256 algorithm.
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static bool DecryptFile(string inputFilePath, string outputFilePath, string key, byte[] iv)
        {
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create))
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        aes.Mode = CipherMode.CBC;
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
