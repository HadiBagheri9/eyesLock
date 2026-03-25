using System;
using System.Windows.Forms;
using eyeStar_ClassLibrary;

namespace eyeLock
{
    public partial class FrmLogin : FrmTemp
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.SetTheme();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLogin, "Login to the software.");
            toolTip.SetToolTip(btnCancel, "Cancel and exit the software.");
            toolTip.SetToolTip(chkShowPassword, "Enable : Show password.");
            toolTip.SetToolTip(eyeLockLogo, "About eyeLock");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
    }
}
