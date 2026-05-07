using System;

namespace eyesLock
{
    public partial class FrmShowSeed : FrmTemp
    {
        private string[] the12SeedPhrases = new string[12];
        private string the13thSeedPhrase;
        public FrmShowSeed(string[] the12SeedPhrases, string the13thSeedPhrase)
        {
            InitializeComponent();
            this.SetTheme();
            this.the12SeedPhrases = the12SeedPhrases;
            this.the13thSeedPhrase = the13thSeedPhrase;
        }

        private void FrmShowSeed_Load(object sender, EventArgs e)
        {
            lbl1.Text = the12SeedPhrases[0];
            lbl2.Text = the12SeedPhrases[1];
            lbl3.Text = the12SeedPhrases[2];
            lbl4.Text = the12SeedPhrases[3];
            lbl5.Text = the12SeedPhrases[4];
            lbl6.Text = the12SeedPhrases[5];
            lbl7.Text = the12SeedPhrases[6];
            lbl8.Text = the12SeedPhrases[7];
            lbl9.Text = the12SeedPhrases[8];
            lbl10.Text = the12SeedPhrases[9];
            lbl11.Text = the12SeedPhrases[10];
            lbl12.Text = the12SeedPhrases[11];

            lbl13.Text = the13thSeedPhrase;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
