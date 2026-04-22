namespace eyesLock
{
    class Global
    {
        /// <summary>
        /// The 12 Mnemonic phrases.
        /// </summary>
        public static string _SeedPhrase { get; set; } = "";

        /// <summary>
        /// The 13th Mnemonic phrase.
        /// </summary>
        public static string _Seed13thPhrase { get; set; } = "";

        /// <summary>
        /// File Encrytion Base String.
        /// </summary>
        public static string  _FE_Base { get; set; }

        /// <summary>
        /// File Encryption Bridge String.
        /// </summary>
        public static string _FE_Bridge { get; set; }

        /// <summary>
        /// File Encryption Digital Key.
        /// </summary>
        public static string _FE_DK { get; set; }

        /// <summary>
        /// File Encryption Digital Initial Vector.
        /// </summary>
        public static byte[] _FE_DV { get; set; }

        /// <summary>
        /// Name of the Recovery file.
        /// </summary>
        public static string _RecoveryFileName = "recovery.txt";

        /// <summary>
        /// The extension of the encrypted files.
        /// </summary>
        public static string _EncryptedFileExtension = ".eye";

        /// <summary>
        /// Seed Phrase File Format
        /// </summary>
        public static string seedPhraseFileFormat = ".eyesph";

        /// <summary>
        /// Sleep time between operating each file.
        /// </summary>
        public static int _CryptographySleepTime = 10;

        /// <summary>
        /// Size of the keys in Bytes.
        /// </summary>
        public static byte _DigitalKeySize = 32;

    }
}
