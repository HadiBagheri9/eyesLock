using System.Text;
using System.Security.Cryptography;

namespace eyesLock
{
    class Key_IV_Generator
    {
        /// <summary>
        /// It returns the File Encryption Bridge String.
        /// </summary>
        /// <param name="_Base">File Encryption Base String</param>
        /// <returns></returns>
        public static string HApproach(string _Base)
        {
            string _Bridge = "";
            SHA512 sha512 = SHA512.Create();
            byte[] hashed = sha512.ComputeHash(
                Encoding.UTF8.GetBytes(_Base)
                );

            for (int i = 0; i < hashed.Length; i++)
            {
                if (hashed[i] > 126)
                {
                    hashed[i] -= 129;
                }

                if (hashed[i] < 33)
                {
                    hashed[i] += 33;
                }
            }
            foreach (var hashedPerByte in hashed)
            {
                _Bridge += (char)hashedPerByte;
            }

            return _Bridge;
        }

        /// <summary>
        /// It returns the File Encryption Digital Key.
        /// </summary>
        /// <param name="_Bridge">File Encryption Bridge String</param>
        /// <param name="keySize">Key Size(Bytes)</param>
        /// <returns></returns>
        public static string HMethod_DK(string _Bridge, byte keySize)
        {
            string _DK = "";
            for (int i = 0; i < _Bridge.Length && _DK.Length != keySize; i++)
            {
                _DK += _Bridge[i];
            }

            return _DK;
        }

        /// <summary>
        /// It returns the File Encryption Digital Initial Vector as a 16-byte String.
        /// </summary>
        /// <param name="_Bridge">File Encryption Bridge String</param>
        /// <returns></returns>
        public static string HMethod_DV(string _Bridge)
        {
            string _DV = "";
            for (int i = _Bridge.Length - 1; i >= 0 && _DV.Length != 16; i--)
            {
                _DV += _Bridge[i];
            }
            return _DV;
        }

    }
}
