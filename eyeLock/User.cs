using System;
using eyeStar_ClassLibrary;

namespace eyeLock
{
    class User
    {
        public static string _Username { get; } = "$2a$13$RE5xqjFB1.s3gPLDTXjZWuhyRNQWqLqC4QNXfHFBILqCVg1DVa6cC";
        public static string _Password { get; } = "$2a$13$32Ue8m6w6wf4EmnGxUWokOVyCu30.PFNxR6uX7dp151ArRyDvfSVu";
        public static string _LicenseKey { get; } = "Fj7YP6OcXeKetQWdgyT2/7bEX4ipbN9ImW5Rq/WVltE=";
        public static string _16ByteKey { get; } = eyeLicense.GtKySxTnBt(_LicenseKey);
        public static DateTime _Expiration { get; } = new DateTime(2035, 01, 01);

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
