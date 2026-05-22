using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace eyesLock
{
    static class Theme
    {
        // Dark Theme Values
        private static Color DarkBack = Color.FromArgb(54, 54, 54);
        private static Color LightFore = Color.FromArgb(224, 224, 224);

        // Light Theme Values
        private static Color LightBack = Color.FromArgb(199, 199, 199);
        private static Color DarkFore = Color.FromArgb(26, 26, 26);

        /// <summary>
        /// Set the application theme based on system theme.
        /// </summary>
        /// <param name="frm"></param>
        public static bool SetTheme(this Form frm)
        {
            bool? flag = CheckDarkModeOnOrOff();

            if (flag == true)
            {
                frm.BackColor = DarkBack;
                frm.ForeColor = LightFore;
                // Return Dark Mode Flag
                return true;
            }
            else if (flag == false)
            {
                frm.BackColor = LightBack;
                frm.ForeColor = DarkFore;
                // Return Light Mode Flag
                return false;
            }
            else
            {
                // Return Light Mode Flag
                return true;
            }
        }

        /// <summary>
        /// Check if the system dark mode theme is on or off.
        /// </summary>
        /// <returns></returns>
        private static bool? CheckDarkModeOnOrOff()
        {
            const string registryKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string valueName = "AppsUseLightTheme";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    object value = key.GetValue(valueName);
                    if (value != null && (int)value == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
