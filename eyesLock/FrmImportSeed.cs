using System.Windows.Forms;

namespace eyesLock
{
    public partial class FrmImportSeed : FrmTemp
    {
        public FrmImportSeed()
        {
            this.SetTheme();
            InitializeComponent();
        }

        private void FrmImportSeed_Load(object sender, System.EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnManualImport, "Manual Import");
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
    }
}
