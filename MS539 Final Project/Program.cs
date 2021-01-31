// CWW 
// UAT MS539 Final Project: Codename: Monkey Mayhem
// a0.01
// weekly goal for 1/31/21: 
// 1) Menu items work
// 2) results can be written to a file
// 3) a loop the user can repeat the menu until they choose the exit (LOSE/QUIT) button.
// 4) Add a random # generation to use in one of the menu item calculations.
//
// currently working and ready for testing are the vs. CPU/difficulty select/main menu loop.  Player can enter this loop as much as they like
// and exit when ready to meet requirement.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS539_Final_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static vsCPU ovsCPU;
        public static vsPlayer ovsPlayer;
        public static GameWindow oGameWindow;
        public static MainMonkey oMainMenu;
        public static GameCore oGameCore = new GameCore();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMonkey());
        }

     
    }
}
