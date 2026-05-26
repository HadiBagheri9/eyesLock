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

            foreach (var hashedPerByte in hashed)
            {
                _Bridge += (char)hashedPerByte;
            }
            _Bridge = CrystalizeString(_Bridge);

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

            for (int i = 0; i < (_Bridge.Length - 1) && _DK.Length != keySize; i += 2)
            {
                _DK += (char)(_Bridge[i] ^ _Bridge[i + 1]);
            }

            _DK = CrystalizeString(_DK);

            return _DK;
        }

        /// <summary>
        /// It returns the File Encryption Digital Initial Vector as a 16-byte String.
        /// </summary>
        /// <param name="_Bridge">File Encryption Bridge String</param>
        /// <returns></returns>
        public static string HMethod_DV(string _DK)
        {
            string _DV = "";

            for (int i = 0; i < (_DK.Length - 1) && _DV.Length != 16; i += 2)
            {
                _DV += (char)(_DK[i] ^ _DK[i + 1]);
            }

            _DV = CrystalizeString(_DV);

            return _DV;
        }
        /// <summary>
        /// Convert a random string to a standard string.
        /// </summary>
        /// <param name="hashed"></param>
        /// <returns></returns>
        public static string CrystalizeString(string hashed)
        {
            string newHashed = "";

            for (int i = 0; i < hashed.Length; i++)
            {
                if (hashed[i] > 126)
                {
                    newHashed += (char)(hashed[i] - 129);

                }
                else if (hashed[i] < 33)
                {
                    newHashed += (char)(hashed[i] + 33);
                }
                else
                {
                    newHashed += hashed[i];
                }

            }

            return newHashed;
        }

    }
}
