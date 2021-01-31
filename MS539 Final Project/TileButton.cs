// CWW
// MS539 Final Project
// This class extends the base button class and stores with it the map location (iXpos/iYpos), the occupant ID, and the associated image.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS539_Final_Project
{
    public class TileButton : Button
    {
        private int iXPos;
        private int iYPos;
        private int iOccupantId;
        private string sImage;
        public int IXPos { get => iXPos; set => iXPos = value; }
        public int IYPos { get => iYPos; set => iYPos = value; }
        public int IOccupantId { get => iOccupantId; set => iOccupantId = value; }
        public string SImage { get => sImage; set => sImage = value; }
    }
}
