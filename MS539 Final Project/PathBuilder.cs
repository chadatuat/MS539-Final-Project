using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS539_Final_Project
{
    public static class PathBuilder
    {

        public static List<string> MakeViableMap(int x, int y)
        {
            char[,] oChars;
            Random rand = new Random(); 
            int iTempX = 0;
            int iTempY = 0;
            int iModX = 0;
            int iModY = 0;
            int iStuckCounter = 0;
            bool bAcceptable = false;
            int iMasterCount = 0;                        
            List<string> lCoords = new List<string>();
            List<string> lBanned = new List<string>();
            oChars = new char[x, y];
            do
            {
                lCoords.Clear();
                lBanned.Clear();
                oChars = new char[x, y];
                for (int iX = 0; iX < x; iX++)
                {
                    for (int iY = 0; iY < y; iY++)
                    {
                        oChars[iX, iY] = '*';
                    }
                }
                iTempX = 0;
                iTempY = 0;
                iModX = 0;
                iModY = 0;
                iStuckCounter = 0;
                bAcceptable = false;
                // determine first acceptable direction E or S
                switch (rand.Next(10) % 2)
                {
                    case 0:
                        oChars[0, 0] = 'E';
                        iModX = 1;
                        break;
                    case 1:
                        oChars[0, 0] = 'S';
                        iModY = 1;
                        break;
                }                
                lCoords.Add(MakeCoords(iTempX, iTempY));
                do
                {
                    // DrawMap(10, 7);
                    iTempX += iModX;
                    iTempY += iModY;
                    // check for destination
                    if (iTempX == 9)
                    {
                        if (iTempY == 6)
                        {
                            bAcceptable = true;
                            oChars[9, 6] = '!';                            
                            iMasterCount = 200;
                            lCoords.Add(MakeCoords(iTempX, iTempY));
                        }
                    }

                    if (bAcceptable == false)
                    {
                        // ensure that this is not blacklisted
                        if (lBanned.Contains(MakeCoords(iTempX, iTempY)))
                        {
                            string[] sSplitter = lCoords[lCoords.Count - 1].Split(',');
                            lCoords.RemoveAt(lCoords.Count - 2);
                            iTempX = Int32.Parse(sSplitter[0]);
                            iTempY = Int32.Parse(sSplitter[1]);
                            oChars[iTempX, iTempY] = '@';
                            // roll back
                            iModX = 0;
                            iModY = 0;
                            sSplitter = lCoords[lCoords.Count - 2].Split(',');
                            iTempX = Int32.Parse(sSplitter[0]);
                            iTempY = Int32.Parse(sSplitter[1]);
                            lCoords.RemoveAt(lCoords.Count - 1);
                        }
                        else
                        {
                            // detect a loop
                            if (lCoords.Contains(MakeCoords(iTempX, iTempY)))
                            {
                                // is bad, roll back
                                iTempX -= iModX;
                                iTempY -= iModY;
                                iStuckCounter++;
                                if (iStuckCounter == 50)
                                {
                                    lBanned.Add(MakeCoords(iTempX, iTempY));
                                    string[] sSplitter = lCoords[lCoords.Count - 1].Split(',');
                                    lCoords.RemoveAt(lCoords.Count - 2);
                                    iTempX = Int32.Parse(sSplitter[0]);
                                    iTempY = Int32.Parse(sSplitter[1]);
                                    oChars[iTempX, iTempY] = '@';                                    
                                    iModX = 0;
                                    iModY = 0;
                                    sSplitter = lCoords[lCoords.Count - 2].Split(',');
                                    iTempX = Int32.Parse(sSplitter[0]);
                                    iTempY = Int32.Parse(sSplitter[1]);
                                    lCoords.RemoveAt(lCoords.Count - 1);
                                }
                            }
                            else
                            {
                                lCoords.Add(MakeCoords(iTempX, iTempY));
                                iStuckCounter = 0;
                            }
                            iModX = 0;
                            iModY = 0;
                            bool bReroll = true;
                            do
                            {
                                bReroll = true;
                                // change direction, but prevent rolling off map
                                switch (rand.Next(40) % 4)
                                {
                                    case 0:
                                        if (iTempX < 9)
                                        {
                                            iModX = 1;
                                            bReroll = false;
                                            oChars[iTempX, iTempY] = 'E';
                                        }
                                        break;
                                    case 1:
                                        if (iTempX > 0)
                                        {
                                            iModX = -1;
                                            bReroll = false;
                                            oChars[iTempX, iTempY] = 'W';
                                        }
                                        break;
                                    case 2:
                                        if (iTempY < 6)
                                        {
                                            iModY = 1;
                                            bReroll = false;
                                            oChars[iTempX, iTempY] = 'S';
                                        }
                                        break;
                                    case 3:
                                        if (iTempY > 0)
                                        {
                                            iModY = -1;
                                            bReroll = false;
                                            oChars[iTempX, iTempY] = 'N';
                                        }
                                        break;
                                }
                            } while (bReroll);
                        }
                    }
                    iMasterCount++;
                    if (iMasterCount == 200)
                    {
                        if (bAcceptable == false)
                        {
                            bAcceptable = true;
                            iMasterCount = 0;
                        }
                    }
                } while (bAcceptable == false);

            } while (iMasterCount < 200);            
            return lCoords;
        }
        public static string MakeCoords(int x, int y)
        {
            return x.ToString() + "," + y.ToString();
        }

    }
}
