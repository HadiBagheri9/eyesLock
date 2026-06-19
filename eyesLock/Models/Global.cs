/*
 Copyright (C) 2026 [HadiBagheri9]
 SPDX-License-Identifier: GPL-3.0-only
*/
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
        public static string _SeedPhrase { get; set; } = "";

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
        public static string _EYES_FileExtension { get; } = ".eyes";

        /// <summary>
        /// Seed Phrase File Format
        /// </summary>
        public static string _EYESPH_FileExtension { get; } = ".eyesph";

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
        /// Github full path of the icon files to download.
        /// </summary>
        public static string _EYES_IconDownloadAddress { get; } = @"https://raw.githubusercontent.com/HadiBagheri9/eyesLock/refs/heads/master/eyes-icon-256px.ico";
        public static string _EYESPH_IconDownloadAddress { get; } = @"https://raw.githubusercontent.com/HadiBagheri9/eyesLock/refs/heads/master/eyesph-icon-256px.ico";

        /// <summary>
        /// Path of the folder which icon file will be saved in.
        /// </summary>
        public static string _IconsSaveAddressFolder { get; } = @"C:\Users\Public\Public Icons";

        /// <summary>
        /// Name of the icon files to be added to the path of folder to save.
        /// </summary>
        public static string _EYES_IconSaveFileName { get; } = "\\eyes_file_icon_256px.ico";
        public static string _EYESPH_IconSaveFileName { get; } = "\\eyesph_file_icon_256px.ico";

        /// <summary>
        /// Name for the encrypted file format.
        /// </summary>
        public static string _EYES_IconTypeName { get; } = "EYES";
        public static string _EYESPH_IconTypeName { get; } = "EYESPH";

        /// <summary>
        /// Discription for the encrypted file format.
        /// </summary>
        public static string _EYES_IconDiscription { get; } = "Locked-eyes file.";
        public static string _EYESPH_IconDiscription { get; } = "Seed-Phrase-eyes key file.";
    }
}
