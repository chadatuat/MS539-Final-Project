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
        private bool bNorthOpen;
        private bool bSouthOpen;
        private bool bEastOpen;
        private bool bWestOpen;

        public TileButton(int iXPos, int iYPos, int iOccupantId, string sImage, bool bNorthOpen, bool bSouthOpen, bool bEastOpen, bool bWestOpen)
        {
            this.iXPos = iXPos;
            this.iYPos = iYPos;
            this.iOccupantId = iOccupantId;
            this.sImage = sImage;
            this.BNorthOpen = bNorthOpen;
            this.BSouthOpen = bSouthOpen;
            this.BEastOpen = bEastOpen;
            this.BWestOpen = bWestOpen;
        }
        public TileButton()
        {
            this.iXPos = 0;
            this.iYPos = 0;
            this.iOccupantId = 0;
            this.sImage = "";
            this.BNorthOpen = false;
            this.BSouthOpen = false;
            this.BEastOpen = false;
            this.BWestOpen = false;
        }

        public int IXPos { get => iXPos; set => iXPos = value; }
        public int IYPos { get => iYPos; set => iYPos = value; }
        public int IOccupantId { get => iOccupantId; set => iOccupantId = value; }
        public string SImage { get => sImage; set => sImage = value; }
        public bool BNorthOpen { get => bNorthOpen; set => bNorthOpen = value; }
        public bool BSouthOpen { get => bSouthOpen; set => bSouthOpen = value; }
        public bool BEastOpen { get => bEastOpen; set => bEastOpen = value; }
        public bool BWestOpen { get => bWestOpen; set => bWestOpen = value; }
    }
}
