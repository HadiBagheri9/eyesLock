using eyeStar_ClassLibrary;

namespace eyeLock
{
    class Global
    {
        public static string _LKE_DK { get; } = eye_Key_IV.HMethod_DK(eye_Key_IV.HApproach("Hadi"));
        public static string _FE_Base { get; set; }
        public static string _FE_Bridge { get; set; }
        public static string _FE_DK { get; set; }
        public static byte[] _FE_DV { get; set; } = new byte[16];
    }
}
