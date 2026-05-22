using System;
using System.Windows.Forms;

namespace eyesLock
{
    public partial class FrmAboutUs : FrmTemp
    {
        public FrmAboutUs()
        {
            InitializeComponent();
            this.SetTheme();
        }

        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            //Check after accomplishing the development operation

            //lbl.Text = eyeAboutSoftwares.eyeLockDiscription;
            //lbl2.Text = eyeAboutSoftwares.eyeLockExplain;
            //lbl3.Text = eyeAboutSoftwares.eyeLockContactUs;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClose, "Close this form.");
            toolTip.SetToolTip(eyeStarLogo, "eyeStar");
            toolTip.SetToolTip(eyeLockLogo, "eyeLock");
        }
    }
}
