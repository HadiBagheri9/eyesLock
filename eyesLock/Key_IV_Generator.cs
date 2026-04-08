using System.Security.Cryptography;
using System.Text;

namespace eyesLock
{
    class Key_IV_Generator
    {
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
        public static string HMethod_DK(string _Bridge, byte keySize)
        {
            string _DK = "";
            for (int i = 0; i < _Bridge.Length && _DK.Length != keySize; i++)
            {
                _DK += _Bridge[i];
            }

            return _DK;
        }

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
