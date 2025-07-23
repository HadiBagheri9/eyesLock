using System;
using eyeStarClassLibrary;
using PersonalClassLibrary.Notif;
using System.Windows.Forms;

namespace eyeLock
{
    public partial class FrmAboutUs : FrmTemp
    {
        public FrmAboutUs()
        {
            if (User.CheckLicense())
            {
                if (!User.CheckExpiration())
                {
                    InitializeComponent();
                    this.SetTheme();
                }
                else
                {
                    eyeMessageContents.LicenseExpired.MessageBoxError();
                    Environment.Exit(0);
                }
            }
            else
            {
                eyeMessageContents.LicenseInvalid.MessageBoxError();
                Environment.Exit(0);
            }
        }
    }
}
