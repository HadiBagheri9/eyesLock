using eyeStar_ClassLibrary;

namespace eyeLock
{
    class Global
    {
        //public static string _LKE_DK { get; } = eye_Key_IV.HMethod_DK(eye_Key_IV.HApproach("Hadi"));//license
        public static string _FE_Base { get; set; } = "test";
        public static string _FE_Bridge { get; set; } = eye_Key_IV.HApproach(Global._FE_Base);//1
        public static string _FE_DK { get; set; } = eye_Key_IV.HMethod_DK(Global._FE_Bridge);//1
        public static byte[] _FE_DV { get; set; } = new byte[16];//1
    }
}
