using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace eyesLock
{
    static partial class FileOptions
    {
        /// <summary>
        /// Get list of the existed Seed Phrase files in startup path and return file paths as a list.
        /// </summary>
        /// <returns></returns>
        public static List<string> ListSeedPhrases()
        {
            List<string> listFiles = new List<string>();
            string[] arrayFiles = Directory.GetFiles(Application.StartupPath, $"*{Global.seedPhraseFileFormat}");
            foreach (var item in arrayFiles)
            {
                listFiles.Add(item);
            }

            return listFiles;
        }

        public static string[] Get12SeedPhrases(this string[] seedPhraseVariable, string seedPhraseContent)
        {
            string[] getContents = seedPhraseContent.Split(Global._SeedPhraseSeparator[0]);

            for (int i = 0; i < seedPhraseVariable.Length; i++)
            {
                seedPhraseVariable[i] = getContents[i].Trim();
            }
            return seedPhraseVariable;
        }
    }
}
