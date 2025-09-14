using System;
using eyeStar_ClassLibrary;
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
                    eyeMessageContents.LicenseExpired.MessageBoxError("eyeLock Error");
                    Environment.Exit(0);
                }
            }
            else
            {
                eyeMessageContents.LicenseInvalid.MessageBoxError("eyeLock Error");
                Environment.Exit(0);
            }
        }

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            lbl.Text = eyeAboutSoftwares.eyeLockDiscription;
            lbl2.Text = eyeAboutSoftwares.eyeLockExplain;
            lbl3.Text = eyeAboutSoftwares.eyeLockContactUs;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClose, "Close this form.");
            toolTip.SetToolTip(eyeStarLogo, "eyeStar");
            toolTip.SetToolTip(eyeLockLogo, "eyeLock");
        }
    }
}
