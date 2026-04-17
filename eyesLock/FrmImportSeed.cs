using System.Windows.Forms;

namespace eyesLock
{
    public partial class FrmImportSeed : FrmTemp
    {
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
            foreach (Control item in this.Controls)
            {
                if (item is TextBox && item.Name != "txtSeed13")
                {
                    //Check Bip39 Else Return
                }
            }

            // 1 Check If they are all from bip39 List
            Global._SeedPhrase = string.Format($"{txtSeed1.Text.Trim()}{txtSeed2.Text.Trim()}{txtSeed3.Text.Trim()}" +
                $"{txtSeed4.Text.Trim()}{txtSeed5.Text.Trim()}{txtSeed6.Text.Trim()}" +
                $"{txtSeed7.Text.Trim()}{txtSeed8.Text.Trim()}{txtSeed9.Text.Trim()}" +
                $"{txtSeed10.Text.Trim()}{txtSeed11.Text.Trim()}{txtSeed12.Text.Trim()}");
            if (chk13thPhrase.Checked == true && !txtSeed13.Text.Equals(""))
            {
                Global._Seed13thPhrase = txtSeed13.Text.Trim();
            }

            //Open FrmPassword Condition.Set
        }
    }
}
