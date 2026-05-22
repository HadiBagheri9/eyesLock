using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace eyesLock
{
    static partial class FileOptions
    {
        /// <summary>
        /// Get list of the existed Seed Phrase files in startup path and return file paths as a list.
        /// </summary>
        /// <returns></returns>
        public static List<string> ListSeedPhraseFiles()
        {
            List<string> listFiles = new List<string>();
            string[] arrayFiles = Directory.GetFiles(Application.StartupPath, $"*{Global.seedPhraseFileFormat}");
            foreach (var item in arrayFiles)
            {
                listFiles.Add(item);
            }

            return listFiles;
        }

        /// <summary>
        /// Get 12 Seed Phrases and return them as a String Array
        /// </summary>
        /// <param name="seedPhraseVariable"></param>
        /// <param name="seedPhraseContent"></param>
        /// <returns></returns>
        public static string[] Get12SeedPhrases(this string[] seedPhraseVariable, string seedPhraseContent)
        {
            string[] getContents = seedPhraseContent.Split(Global._SeedPhraseSeparator);

            for (int i = 0; i < seedPhraseVariable.Length; i++)
            {
                seedPhraseVariable[i] = getContents[i].Trim();
            }
            return seedPhraseVariable;
        }

        /// <summary>
        /// Get the 13th Seed Phrase and return it as a String Variable
        /// </summary>
        /// <param name="seedPhraseVariable"></param>
        /// <param name="seedPhraseContent"></param>
        /// <returns></returns>
        public static string Get13thSeedPhrase(this string seedPhraseVariable, string seedPhraseContent)
        {
            seedPhraseVariable = "";
            string[] getContents = seedPhraseContent.Split(Global._SeedPhraseSeparator);

            if (getContents.Length > 12)
            {
                for (int i = 12; i < getContents.Length; i++)
                {
                    seedPhraseVariable += getContents[i];
                }
            }

            return seedPhraseVariable.Trim();
        }
    }
}
