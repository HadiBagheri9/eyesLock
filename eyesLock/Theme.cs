using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;

namespace eyesLock
{
    static class Theme
    {
        // Dark Theme
        private static Color DarkBack = Color.FromArgb(54, 54, 54);
        private static Color LightFore = Color.FromArgb(224, 224, 224);

        // Light Theme
        private static Color LightBack = Color.FromArgb(199, 199, 199);
        private static Color DarkFore = Color.FromArgb(26, 26, 26);

        public static void SetTheme(this Form frm)
        {
            bool? flag = CheckDarkModeOnOrOff();

            if (flag == true)
            {
                frm.BackColor = DarkBack;
                frm.ForeColor = LightFore;
                return;
            }
            else if (flag == false)
            {
                frm.BackColor = LightBack;
                frm.ForeColor = DarkFore;
                return;
            }
            else
            {
                return;
            }
        }


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
