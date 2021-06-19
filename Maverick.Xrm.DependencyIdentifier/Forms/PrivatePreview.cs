using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maverick.Xrm.DependencyIdentifier.Forms
{
    public partial class PrivatePreview : Form
    {
        public PrivatePreview()
        {
            InitializeComponent();
        }

        private void linklblDanish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/DanzMaverick");
        }

        private void linklblArun_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/ArunVinoth");
        }

        private void linklblLinn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/LinnZawWin");
        }

        private void btnSubmitSecretKey_Click(object sender, EventArgs e)
        {
            string secretKey = Properties.Settings.Default["SecretKey"].ToString();

            if (secretKey == txtSecretKey.Text)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Secret Key", "Secret Key Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
