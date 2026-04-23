using System;

namespace eyesLock
{
    public enum FrmPasswordType { Set, Enter};
    
    public partial class FrmPassword : FrmTemp
    {
        public string _Password, _Title;
        private FrmPasswordType? frmPasswordType = null;
        public FrmPassword(FrmPasswordType frmPasswordType)
        {
            InitializeComponent();
            this.SetTheme();
            this.frmPasswordType = frmPasswordType;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            label2.Text = frmPasswordType.ToString() + " " + "Password : ";
            btnOK.Text = frmPasswordType.ToString();

            txtTitle.Enabled = (frmPasswordType == FrmPasswordType.Set);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _Password = null;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // 1 Needs Conditions
            if (frmPasswordType == FrmPasswordType.Set)
            {
                _Password = txtPassword.Text.Trim();
                _Title = txtTitle.Text.Trim();

                Close();
            }
            else
            {
                _Password = txtPassword.Text.Trim();

                Close();
            }
        }
    }
}
