using System;
using eyeStarClassLibrary;
using PersonalClassLibrary.Notif;

namespace eyeLock
{
    public partial class FrmLogin : FrmTemp
    {
        public FrmLogin()
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
