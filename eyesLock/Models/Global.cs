namespace eyesLock
{
    class Global
    {
        /// <summary>
        /// Check error for each part.
        /// </summary>
        public static bool _HasError { get; set; }

        /// <summary>
        /// The 12 Mnemonic phrases.
        /// </summary>
        public static string[] _SeedPhrase { get; set; } = new string[12];

        /// <summary>
        /// The 13th Mnemonic phrase.
        /// </summary>
        public static string _Seed13thPhrase { get; set; } = "";

        /// <summary>
        /// Path for the bip39 file.
        /// </summary>
        //public static string _Bip39File { get; } = "bip39.txt";

        /// <summary>
        /// File Encrytion Base String.
        /// </summary>
        public static string _FE_Base { get; set; }

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
        public static string _RecoveryFileName { get; } = "recovery.txt";

        /// <summary>
        /// The extension of the encrypted files.
        /// </summary>
        public static string _EncryptedFileExtension { get; } = ".eyes";

        /// <summary>
        /// Seed Phrase File Format
        /// </summary>
        public static string seedPhraseFileFormat { get; } = ".eyesph";

        /// <summary>
        /// Sleep time between operating each file.
        /// </summary>
        public static int _CryptographySleepTime { get; } = 10;

        /// <summary>
        /// Size of the keys in Bytes.
        /// </summary>
        public static byte _DigitalKeySize { get; } = 32;

        /// <summary>
        /// A variable that is used in Seed Phrase Files to separate words.
        /// </summary>
        public static char _SeedPhraseSeparator { get; } = '|';

        /// <summary>
        /// Github full path of the icon file to download.
        /// </summary>
        //public static string _IconDownloadAddress { get; } = @"https://raw.githubusercontent.com/HadiBagheri9/eyesLock/refs/heads/master/eyesLock/Resources/eyeFileFormatIcon.ico";
        public static string _IconDownloadAddress { get; } = @"https://raw.githubusercontent.com/HadiBagheri9/IconDownloadTest/refs/heads/main/eyeFileFormatIcon.ico";

        /// <summary>
        /// Path of the folder which icon file will be saved in.
        /// </summary>
        public static string _IconSaveAddressFolder { get; } = @"C:\Users\Public\Public Icons";

        /// <summary>
        /// Name of the icon file to be added to the path of folder to save.
        /// </summary>
        public static string _IconSaveFileName { get; } = "\\eye_file_256px.ico";

        /// <summary>
        /// Name for the encrypted file format.
        /// </summary>
        public static string _EncryptedFileTypeName { get; } = "EYES";

        /// <summary>
        /// Discription for the encrypted file format.
        /// </summary>
        public static string _EncryptedFileTypeDiscription { get; } = "Locked-eyes file.";
    }
}
