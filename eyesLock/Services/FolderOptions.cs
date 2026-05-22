using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;

namespace eyesLock
{
    class FolderOptions
    {
        /// <summary>
        /// Disable user accessibility to a directory.
        /// </summary>
        /// <param name="path"></param>
        public static void LockDirectory(string path)
        {
            DirectorySecurity ds = Directory.GetAccessControl(path);
            FileSystemAccessRule fsar = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.AddAccessRule(fsar);
            Directory.SetAccessControl(path, ds);
        }

        /// <summary>
        /// Ensable user accessibility to a directory.
        /// </summary>
        /// <param name="path"></param>
        public static void UnLockDirectory(string path)
        {
            DirectorySecurity ds = Directory.GetAccessControl(path);
            FileSystemAccessRule fsar = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.RemoveAccessRule(fsar);
            Directory.SetAccessControl(path, ds);
        }

        /// <summary>
        /// Get all file paths in a specific directory with defined exceptions and return them as a list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetAllFiles(string path)
        {
            string[] arrayFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            List<string> listFiles = new List<string>();

            foreach (var item in arrayFiles)
            {
                if (item.Contains("RECYCLE") ||
                            item.Contains("Config.Msi") ||
                            item.Contains("System Volume Information"))
                {
                    continue;
                }
                try
                {
                    listFiles.Add(item);
                }
                catch
                {
                    continue;
                }
            }
            return listFiles;
        }

        /// <summary>
        /// Get all folder paths in a specific directory with defined exceptions and return them as a list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetAllFolders(string path)
        {
            string[] arrayFiles = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
            List<string> listFolders = new List<string>();

            foreach (var item in arrayFiles)
            {
                if (item.Contains("RECYCLE") ||
                            item.Contains("Config.Msi") ||
                            item.Contains("System Volume Information"))
                {
                    continue;
                }
                try
                {
                    listFolders.Add(item);
                }
                catch
                {
                    continue;
                }
            }
            return listFolders;
        }
    }
}
