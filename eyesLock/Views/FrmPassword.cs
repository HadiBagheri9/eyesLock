using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace eyesLock
{
    public enum FrmPasswordType { Set, Enter, Show};
    
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
            listFiles = (frmPasswordType == FrmPasswordType.Enter || frmPasswordType == FrmPasswordType.Show) ? FileOptions.ListSeedPhrases() : new List<string>();

            // Fill 
            if (listFiles.Count > 0 && (frmPasswordType == FrmPasswordType.Enter || frmPasswordType == FrmPasswordType.Show))
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
            else if (frmPasswordType == FrmPasswordType.Enter)
            {
                // Set Decryption Parameters
                string _SE_Base = txtPassword.Text.Trim();
                string _SE_Bridge = Key_IV_Generator.HApproach(_SE_Base);
                string _SE_DK = Key_IV_Generator.HMethod_DK(_SE_Bridge, Global._DigitalKeySize);
                string _SE_DV = Key_IV_Generator.HMethod_DV(_SE_Bridge);
                Global._HasError = false;

                // Read content of listFile[0] and Decrypt and define
                try
                {
                    seedPhraseFileContent = File.ReadAllText(listFiles[0]);
                    seedPhraseFileContent = TextOptions.Decrypt(seedPhraseFileContent, _SE_DK, Encoding.ASCII.GetBytes(_SE_DV));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global._HasError = true;
                }



                if (!Global._HasError)
                {
                    try
                    {
                        // Check validation of Seed Phrase File
                        Global._SeedPhrase.Get12SeedPhrases(seedPhraseFileContent);
                        Global._Seed13thPhrase = Global._Seed13thPhrase.Get13thSeedPhrase(seedPhraseFileContent);
                        Hide();
                        FrmMain frmMain = new FrmMain();
                        frmMain.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Seed Phrase file is invalid.", "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Secure Variables
                seedPhraseFileContent = null;
                _SE_Base = null;
                _SE_Bridge = null;
                _SE_DK = null;
                _SE_DV = null;
            }
            else
            {
                // Set Decryption Parameters
                string _SE_Base = txtPassword.Text.Trim();
                string _SE_Bridge = Key_IV_Generator.HApproach(_SE_Base);
                string _SE_DK = Key_IV_Generator.HMethod_DK(_SE_Bridge, Global._DigitalKeySize);
                string _SE_DV = Key_IV_Generator.HMethod_DV(_SE_Bridge);
                Global._HasError = false;

                // Read content of listFile[0] and Decrypt and define
                try
                {
                    seedPhraseFileContent = File.ReadAllText(listFiles[0]);
                    seedPhraseFileContent = TextOptions.Decrypt(seedPhraseFileContent, _SE_DK, Encoding.ASCII.GetBytes(_SE_DV));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global._HasError = true;
                }



                if (!Global._HasError)
                {
                    try
                    {
                        // Check validation of Seed Phrase File
                        string[] the12SeedPhrases = new string[12];
                        the12SeedPhrases.Get12SeedPhrases(seedPhraseFileContent);

                        string the13thSeedPhrase = "";
                        the13thSeedPhrase = the13thSeedPhrase.Get13thSeedPhrase(seedPhraseFileContent);

                        Hide();
                        FrmShowSeed frmShowSeed = new FrmShowSeed(the12SeedPhrases, the13thSeedPhrase);

                        // Secure Variables
                        the12SeedPhrases = null;
                        the13thSeedPhrase = null;

                        frmShowSeed.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Seed Phrase file is invalid.", "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Secure Variables
                seedPhraseFileContent = null;
                _SE_Base = null;
                _SE_Bridge = null;
                _SE_DK = null;
                _SE_DV = null;
            }
        }
    }
}
