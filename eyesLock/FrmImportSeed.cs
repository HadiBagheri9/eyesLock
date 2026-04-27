using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace eyesLock
{
    public partial class FrmImportSeed : FrmTemp
    {
        List<string> bip39List = new List<string>();
        
        public FrmImportSeed()
        {
            InitializeComponent();
            this.SetTheme();
        }

        private void FrmImportSeed_Load(object sender, System.EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnImport, "Manual Import");
            toolTip.SetToolTip(btnGenerateNew, "Generate New");

            try
            {
                StreamReader streamReader = new StreamReader(Global._Bip39File);
                while (!streamReader.EndOfStream)
                {
                    bip39List.Add(streamReader.ReadLine().Trim().ToLower());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eyes'Lock");
            }
        }

        private void chk13thPhrase_CheckedChanged(object sender, System.EventArgs e)
        {
            txtSeed13.Enabled = chk13thPhrase.Checked ? true : false;
        }

        private void chkEnterManually_CheckedChanged(object sender, System.EventArgs e)
        {
            txtSeed1.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed2.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed3.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed4.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed5.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed6.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed7.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed8.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed9.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed10.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed11.Enabled = chkEnterManually.Checked ? true : false;
            txtSeed12.Enabled = chkEnterManually.Checked ? true : false;
        }

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            // Check validation of all 12 text boxes
            int validations = 0;
            foreach (Control item in pnlMain.Controls)
            {
                if (item is ThemeTextBox)
                {
                    if (!ValidateWord((ThemeTextBox)item))
                    {
                        MessageBox.Show(item.Text);
                        validations++;
                    }
                }
            }

            // Check if all 12 words are valid
            if (validations > 0)
                return;

            // File Content Variable.
            string seedPhraseFileContent = string.Format($"" +
                $"{txtSeed1.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed2.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed3.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed4.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed5.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed6.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed7.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed8.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed9.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed10.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed11.Text.Trim()}{Global._SeedPhraseSeparator}" +
                $"{txtSeed12.Text.Trim()}{Global._SeedPhraseSeparator}");

            // Check for 13th word.
            if (chk13thPhrase.Checked && !txtSeed13.Text.Equals(""))
            {
                seedPhraseFileContent += txtSeed13.Text.Trim();
            }

            

            FrmPassword frmPassword = new FrmPassword(FrmPasswordType.Set);
            frmPassword.ShowDialog();

            // If frmPassword closed.
            if (string.IsNullOrEmpty(frmPassword._Password))
            {
                return;
            }

            // Set Encryption Parameters
            string _SE_Base = frmPassword._Password;
            string _SE_Bridge = Key_IV_Generator.HApproach(_SE_Base);
            string _SE_DK = Key_IV_Generator.HMethod_DK(_SE_Bridge, 32);
            string _SE_DV = Key_IV_Generator.HMethod_DV(_SE_Bridge);

            try
            {
                // Create the Seed Phrase File.
                File.WriteAllText($"{frmPassword._Title}{Global.seedPhraseFileFormat}", CryptText.Encrypt(seedPhraseFileContent, _SE_DK, Encoding.ASCII.GetBytes(_SE_DV)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "eyes'Lock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Global._SeedPhrase.Get12SeedPhrases(seedPhraseFileContent);
            Global._Seed13thPhrase = Global._Seed13thPhrase.Get13thSeedPhrase(seedPhraseFileContent);
            
            // Secure Variables
            frmPassword.Dispose();
            frmPassword._Password = null;
            seedPhraseFileContent = null;
            _SE_Base = null;
            _SE_Bridge = null;
            _SE_DK = null;
            _SE_DV = null;

            Hide();
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            Close();
        }

        /// <summary>
        /// To check if the entered word in the text box is valid.
        /// </summary>
        /// <param name="txt"></param>
        private bool ValidateWord(ThemeTextBox txt)
        {
            string word = txt.Text.Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(word) && !bip39List.Contains(word))
            {
                txt.BorderColor = Color.Red;
                return false;
            }
            else
            {
                txt.BorderColor = Color.White;
                return true;
            }
        }

        private void btnGenerateNew_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            foreach (Control item in pnlMain.Controls)
            {
                int i = rand.Next(0, bip39List.Count);
                if (item is ThemeTextBox)
                {
                    item.Text = bip39List[i];
                    item.Enabled = false;
                }
            }
        }
    }
}
