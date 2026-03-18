using eyeStar_ClassLibrary;
using System;
using System.Text;

namespace eyeLock
{
    class Global
    {
        //public static string _LKE_DK { get; } = eye_Key_IV.HMethod_DK(eye_Key_IV.HApproach("Hadi"));//license
        public static string _SeedPhrase { get; set; } = "";
        public static string  _FE_Base { get; set; }
        public static string _FE_Bridge { get; set; } //1
        public static string _FE_DK { get; set; } //1
        public static byte[] _FE_DV { get; set; } //1
    }
}
