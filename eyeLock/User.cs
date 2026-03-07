using System;
using eyeStar_ClassLibrary;

namespace eyeLock
{
    class User
    {
        /*
        public static string __User { get; } = "eyestar";
        public static string __Pass { get; } = "Hadi1313";
        public static string __Insta { get; } = "hadi.bagheri.9";
        public static string __Disc { get; } = " ";
        public static string __PaidA { get; } = "0";

        public static string _Username { get; } = "$2a$13$RE5xqjFB1.s3gPLDTXjZWuhyRNQWqLqC4QNXfHFBILqCVg1DVa6cC";
        public static string _Password { get; } = "$2a$13$32Ue8m6w6wf4EmnGxUWokOVyCu30.PFNxR6uX7dp151ArRyDvfSVu";
        */

        /*
        public static DateTime _Expiration { get; } = new DateTime(2095, 01, 01);
        public static string _LicenseKey { get; } = "Fj7YP6OcXeKetQWdgyT2/7bEX4ipbN9ImW5Rq/WVltE=";
        //public static string _FE_DK { get; } = eye_Key_IV.GtKySxTnBt(_LicenseKey);
        */
        public static string _FE_DK { get; set; } = eye_Key_IV.HMethod_DK(eye_Key_IV.HApproach(Global._FE_Base));

        /*
        public static bool CheckLicense()
        {
            //return eyeValidation.CheckUSBLicense(_LicenseKey, Global._LKE_DK);
            return eyeValidation.CheckDeviceLicense(_LicenseKey, Global._LKE_DK);
            //return eyeValidation.CheckUserLicense(_LicenseKey, Global._LKE_DK);
        }*/
        //license

        /*
        public static bool CheckExpiration()
        {
            return eyeValidation.IsSoftwareExpired(_Expiration);
        }*/
    }
}
