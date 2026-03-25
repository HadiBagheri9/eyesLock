using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eyeLock
{
    class FileOptions
    {
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
