// base class from which individual units are derived.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public abstract class UnitType
    {
        int iUnitType;
        int iHealth;
        int iAtkVsGround;
        int iAtkVsAir;
        int iCost;
        int ID;

        public int IUnitType { get => iUnitType; set => iUnitType = value; }
        public int IHealth { get => iHealth; set => iHealth = value; }
        public int IAtkVsGround { get => iAtkVsGround; set => iAtkVsGround = value; }
        public int IAtkVsAir { get => iAtkVsAir; set => iAtkVsAir = value; }
        public int ICost { get => iCost; set => iCost = value; }
        public int ID1 { get => ID; set => ID = value; }
    }
}
