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

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            lbl.Text = eyeAboutSoftwares.eyeLock;
        }

        private void eyeStarLogo_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(eyeStarLogo, "eyeStar");
        }

        private void eyeLockLogo_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(eyeLockLogo, "eyeLock");
        }
    }
}
