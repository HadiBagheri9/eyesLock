using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace eyesLock
{
    public enum FrmPasswordType { Set, Enter};
    
    public partial class FrmPassword : FrmTemp
    {
        public string _Password, _Title;
        private FrmPasswordType? frmPasswordType = null;
        private List<string> listFiles;
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

            // Get List of the Seed Phrase files to Use.
            listFiles = frmPasswordType == FrmPasswordType.Enter ? FileOptions.ListSeedPhrases() : new List<string>();

            // Fill 
            if (listFiles.Count > 0 && frmPasswordType == FrmPasswordType.Enter)
            {
                FileInfo fileInfo = new FileInfo(listFiles[0]);
                txtTitle.Text = fileInfo.Name;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _Password = null;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string seedPhraseFileContent = "";
            // 1 Needs Conditions
            if (frmPasswordType == FrmPasswordType.Set)
            {
                _Password = txtPassword.Text.Trim();
                _Title = txtTitle.Text.Trim();

                Close();
            }
            else
            {
                // Set Decryption Parameters
                string _SE_Base = txtPassword.Text.Trim();
                string _SE_Bridge = Key_IV_Generator.HApproach(_SE_Base);
                string _SE_DK = Key_IV_Generator.HMethod_DK(_SE_Bridge, 32);
                string _SE_DV = Key_IV_Generator.HMethod_DV(_SE_Bridge);

                // Read content of listFile[0] and Decrypt and define
                try
                {
                    seedPhraseFileContent = File.ReadAllText(listFiles[0]);
                    seedPhraseFileContent = TextOptions.Decrypt(seedPhraseFileContent, _SE_DK, Encoding.ASCII.GetBytes(_SE_DV));
                    Global._SeedPhrase.Get12SeedPhrases(seedPhraseFileContent);
                    Global._Seed13thPhrase = Global._Seed13thPhrase.Get13thSeedPhrase(seedPhraseFileContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "eyes'Lock");
                }

                // Secure Variables
                seedPhraseFileContent = null;
                _SE_Base = null;
                _SE_Bridge = null;
                _SE_DK = null;
                _SE_DV = null;

                Hide();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }
        }
    }
}
