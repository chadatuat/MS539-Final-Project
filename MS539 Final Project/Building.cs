// Added for pass 3:
// this class extends unit and is a building with a potential special attack or other function.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public class Building : Unit
    {        
        int iAirDefense;
        int iGroundDefense;
        int iSpecial;

        public int IAirDefense { get => iAirDefense; set => iAirDefense = value; }
        public int IGroundDefense { get => iGroundDefense; set => iGroundDefense = value; }
        public int ISpecial { get => iSpecial; set => iSpecial = value; }

        public Building Create(int x, int y)
        {
            Building iThisBuilding = new Building();
            iThisBuilding.XPos = x;
            iThisBuilding.YPos = y;
            iThisBuilding.ISpeed = 0;
            iThisBuilding.IAirDefense = 10;
            iThisBuilding.IGroundDefense = 10;
            return iThisBuilding;
        }

        public void Update()
        {

        }
        public void Attack(Unit oVictim) // attack a building or unit.
        {

        }

        public void Remove()
        {
            // remove this unit
            // play a cool animation.
        }

    }
}
