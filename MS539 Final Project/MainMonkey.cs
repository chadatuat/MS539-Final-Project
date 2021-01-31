// CWW 
// MS539
// online play is currently disabled.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS539_Final_Project
{
    public partial class MainMonkey : Form
    {
        public MainMonkey()
        {
            InitializeComponent();
            this.onlinePlayButton.Enabled = false;
            Program.oMainMenu = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.ovsCPU == null)
            {
                // open a new window
                Program.ovsCPU = new vsCPU();
            }
            Program.ovsCPU.SetDifficulty();
            Program.ovsCPU.Show();
            this.Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
