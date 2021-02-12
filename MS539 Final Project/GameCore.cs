// CWW
// MS539 Final Project
// now has tools to map out viable game maps - this is still work in progress.
// also has a list of units which represent polymorphism.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public class GameCore
    {
        public int iDifficultyLevel;
        public List<Unit> lUnits = new List<Unit>();
        public List<Building> lBuildings = new List<Building>();

        public GameCore NewGameCore()
        {
            return this;
        }        

        public void RemoveObjects(int iXSize, int iYSize, TileButton[,] oMapArray)
        {
            int iIndex;
            bool bIsUnit = false;
            for (int xPos = 0; xPos < iXSize; xPos++)
            {
                for (int yPos = 0; yPos < iYSize; yPos++)
                {                    
                    iIndex = lUnits.FindIndex(unit => unit.ID1 == oMapArray[xPos, yPos].IOccupantId);
                    if (iIndex > 0)
                    {
                        bIsUnit = true;
                    } 
                    if (bIsUnit)
                    {
                        var RemoveMe = lUnits[iIndex];                        
                    } else
                    {
                        var RemoveMe = lBuildings[lBuildings.FindIndex(unit => unit.ID1 == oMapArray[xPos, yPos].IOccupantId)];
                        if (RemoveMe.IHealth < 1)
                        {
                            RemoveMe.Remove();
                        }
                    }
                    
                }
            }
        }

        public bool IsViableMap(TileButton[,] oMapArray, int xSize, int ySize)
        {
            // in these cases we are asking simple questions where a truthfull answer is a failure: 
            // are there multiple castle routes?  Yes = true = fail condition.  
            // are there out of bounds paths?  Yes = true = fail condition.  
            bool bIsViable = true;
            
            if (HasMultipleCastleRoutes(oMapArray, xSize, ySize)){
                bIsViable = false;
            }

            if (GoGoesOutOfBounds(oMapArray, xSize, ySize))
            {
                //bIsViable = false;
            }

            // check to ensure no routes go out of map
            //return "Is acceptable.";
            return bIsViable;
        }

        public bool HasMultipleCastleRoutes(TileButton[,] oMapArray, int xSize, int ySize)
        {
            bool bHasMultipleCastleRoutes = false;
            // check to ensure both castles are accessible via one route only.
            int iAccessibleSides = 0;
            // is UL castle accessible via the east tile?
            if (oMapArray[1, 0].BWestOpen)
            {
                iAccessibleSides++;
            }
            // is UL castle accessible via the south tile?
            if (oMapArray[0, 1].BNorthOpen)
            {
                iAccessibleSides++;
            }
            // can only have 1 route.
            if (iAccessibleSides != 1)
            {                
                return true;
            }
            iAccessibleSides = 0;
            // is LR castle accessible via the west tile?
            if (oMapArray[(xSize - 2), (ySize - 1)].BEastOpen)
            {
                iAccessibleSides++;
            }
            // is LR castle accessible via the northern tile
            if (oMapArray[(xSize - 1), (ySize - 2)].BSouthOpen)
            {
                iAccessibleSides++;
            }
            // can only have 1 route.
            if (iAccessibleSides != 1)
            {                
                return true;
            }
            return bHasMultipleCastleRoutes;
        }

        public bool TileGoesOutOfBounds(TileButton oThisTileButton, int xSize, int ySize)
        {
            bool bGoesOutOfBounds = false;
            // check east side on x = 1
            if (oThisTileButton.IXPos == 1)
            {
                if (oThisTileButton.BEastOpen)
                {
                    return true;
                }
            }
            // check west side on x = xSize
            if (oThisTileButton.IXPos == xSize)
            {
                if (oThisTileButton.BWestOpen)
                {
                    return true;
                }
            }
            // check north side on y = 1
            if (oThisTileButton.IYPos == 1)
            {
                if (oThisTileButton.BNorthOpen)
                {
                    return true;
                }
            }
            // check east side on y = ySize
            if (oThisTileButton.IYPos == ySize)
            {
                if (oThisTileButton.BSouthOpen)
                {
                    return true;
                }
            }
            return bGoesOutOfBounds;
        }


        public bool GoGoesOutOfBounds(TileButton[,] oMapArray, int xSize, int ySize)
        {
            bool bGoesOutofBounds = false;            
            for (int x = 0; x < xSize; x++)
            {
                // check the N side
                if (oMapArray[x, 0].BNorthOpen)
                {
                    return true;
                }
                // check the S side
                if (oMapArray[x, (ySize - 1)].BSouthOpen)
                {
                    return true;
                }
            }
            for (int y = 0; y < ySize; y++)
            {
                // check the E side      
                if (oMapArray[(xSize - 1), y].BEastOpen)
                {
                    return true;
                }
                // check the W side                      
                if (oMapArray[0, y].BWestOpen)
                {
                    return true;
                }
            }
            return bGoesOutofBounds;
        }
    }
}
