// CWW
// MS539
// functions: SetDifficulty (Called whenever this form is called to reset dificulty to novice.
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
    public partial class vsCPU : Form
    {
        public vsCPU()
        {
            InitializeComponent();
            SetDifficulty();
        }

        public void SetDifficulty()
        {
            this.noviceRadioButton.Select();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Program.ovsCPU.Hide();
            Program.oMainMenu.Show();
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (Program.oGameWindow == null)
            {
                // open a new window
                Program.oGameWindow = new GameWindow();
            }
            Program.oGameWindow.Show();
            this.Hide();
        }
    }
}
