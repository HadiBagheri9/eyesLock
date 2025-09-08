using System;
using System.Windows.Forms;
using eyeStar_ClassLibrary;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (BCrypt.Net.BCrypt.EnhancedVerify(txtUsername.Text.Trim(), User._Username) 
                && BCrypt.Net.BCrypt.EnhancedVerify(txtPassword.Text.Trim(), User._Password))
            {
                Cursor = Cursors.Default;
                Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.ShowDialog();
            }
            else
            {
                Cursor = Cursors.Default;
                "Username and Password are incorrect".MessageBoxError();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void eyeLockLogo_Click(object sender, EventArgs e)
        {
            FrmAboutUs frmAboutUs = new FrmAboutUs();
            frmAboutUs.ShowDialog();
        }

        private void eyeLockLogo_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(eyeLockLogo, "About eyeLock");
        }
    }
}
