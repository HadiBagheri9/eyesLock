using eyeStarClassLibrary;
using System;

namespace eyeLock
{
    class User
    {
        public static string _Username { get; } = "eyeStar";
        public static string _Password { get; } = "Hadi1313";
        public static string _LicenseKey { get; } = "Fj7YP6OcXeKetQWdgyT2/7bEX4ipbN9ImW5Rq/WVltE=";
        public static string _16ByteKey { get; } = eyeLicense.GtKySxTnBt(_LicenseKey);
        public static DateTime _Expiration { get; } = new DateTime(2025, 7, 23);

        public static bool CheckLicense()
        {
            //return eyeValidation.CheckUSBLicense(_LicenseKey, Global._GlobalKey);
            return eyeValidation.CheckDeviceLicense(_LicenseKey, Global._GlobalKey);
            //return eyeValidation.CheckUserLicense(_LicenseKey, Global._GlobalKey);
        }

        public static bool CheckExpiration()
        {
            return eyeValidation.IsSoftwareExpired(_Expiration);
        }
    }
}
