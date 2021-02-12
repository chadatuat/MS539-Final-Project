// Added for pass 3:
// this class extends unit and is an actual unit. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public class Unit : UnitType
    {
        int xPos;
        int yPos;
        int iSpeed;
        

        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int ISpeed { get => iSpeed; set => iSpeed = value; }

        public Unit Create (int x, int y)
        {
            Unit iThisUnit = new Unit();
            iThisUnit.xPos = x;
            iThisUnit.yPos = y;
            iThisUnit.iSpeed = 1;
            return iThisUnit;
        }

        public void Update()
        {

        }        
        public void Attack (Unit oVictim) // attack a building.
        {

        }

        public void Remove()
        {
            // remove this unit
            // play a cool animation.
        }
    }
}
