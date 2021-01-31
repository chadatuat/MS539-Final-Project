// CWW
// MS539 Final Project
// Current functionality - this main game window opens and allows the user to randomize the map.  
// The only non-random factors are the castles in each corner.
// 
// menu items working: save (meets criteria for weekly goal)
// Exit/Quit

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS539_Final_Project
{
    public partial class GameWindow : Form
    {

        public static TileButton[,] oMapArray;
        private static Random _myRandom = new Random();
        public static int iXSize = 7;
        public static int iYSize = 3;
        public List<string> sColorList = new List<string> { "Green", "Yellow" };
        private System.Windows.Forms.SaveFileDialog oSaveFileDialog;

        public GameWindow()
        {
            InitializeComponent();
            drawMap();
        }

        public void unloadMap() {
            for (int xPos = 0; xPos < iXSize; xPos++)
            {
                for (int yPos = 0; yPos < iYSize; yPos++)
                {
                    Controls.Remove(oMapArray[xPos, yPos]);
                }
            }
        }

        public string mapColor()
        {
            int iIndexLocation = _myRandom.Next(50) % sColorList.Count;
            string sColor = sColorList[iIndexLocation];
            return sColor;
        }

        public void drawMap()
        {
            
            string sImageName = "";
            string sColor = "";
            string sPath = "";
            // determine if a map exists, if so, unload it.
            if (oMapArray == null)
            {
                oMapArray = new TileButton[iXSize, iYSize];
            }
            else
            {
                unloadMap();
            }
            // select the map color
            sColor = mapColor();
            for (int xPos = 0; xPos < iXSize; xPos++)                
            {
                for (int yPos = 0; yPos < iYSize; yPos++)
                {
                    oMapArray[xPos, yPos] = new TileButton();
                    oMapArray[xPos, yPos].BackColor = System.Drawing.Color.Transparent;
                    oMapArray[xPos, yPos].Location = new System.Drawing.Point(12 + (xPos * 40), 60 + (yPos * 40));
                    oMapArray[xPos, yPos].Size = new System.Drawing.Size(40, 40);
                    switch (_myRandom.Next(50) % 6)
                    {
                        case 0:
                            sImageName = "L.BMP";
                            break;
                        case 1:
                            sImageName = "L2.BMP";
                            break;
                        case 2:
                            sImageName = "L3.BMP";
                            break;
                        case 3:
                            sImageName = "L4.BMP";
                            break;
                        case 4:
                            sImageName = "ntos.BMP";
                            break;
                        case 5:
                            sImageName = "etow.BMP";
                            break;
                    }
                    // catch the first and last items to ensure that they are castles
                    if (((xPos == 0) && (yPos == 0)) || ((xPos == (iXSize - 1)) && (yPos == (iYSize - 1)))) {
                        sImageName = "castle.bmp";
                    }
                    sPath = @"..\..\Resources\Images\" + sColor + @"\" + sImageName;

                    oMapArray[xPos, yPos].Image = Image.FromFile(sPath);
                    oMapArray[xPos, yPos].ImageAlign = ContentAlignment.TopLeft;
                    oMapArray[xPos, yPos].TabStop = false;
                    oMapArray[xPos, yPos].FlatStyle = FlatStyle.Flat;
                    oMapArray[xPos, yPos].FlatAppearance.BorderSize = 0;                    
                    oMapArray[xPos, yPos].Enabled = true;
                    oMapArray[xPos, yPos].AutoSize = true;                    
                    oMapArray[xPos, yPos].Margin = new Padding(0, 0, 0, 0);
                    oMapArray[xPos, yPos].Padding = new Padding(0, 0, 0 , 0);
                    oMapArray[xPos, yPos].IXPos = xPos + 1;
                    oMapArray[xPos, yPos].IYPos = yPos + 1;
                    oMapArray[xPos, yPos].SImage = sPath;
                    oMapArray[xPos, yPos].IOccupantId = 0;
                    Controls.Add(oMapArray[xPos, yPos]);
                }                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            drawMap();
        }

        private void spellButton_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.oSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            oSaveFileDialog.Title = "Save your map!";
            oSaveFileDialog.InitialDirectory = @"C:\";
            oSaveFileDialog.CheckPathExists = true;
            oSaveFileDialog.DefaultExt = "map";
            oSaveFileDialog.Filter = "Map files (*.map)|*.map|All files (*.*)|*.*";
            oSaveFileDialog.FilterIndex = 2;
            oSaveFileDialog.RestoreDirectory = true;
            oSaveFileDialog.ShowDialog();
            if (oSaveFileDialog.FileName == null)
            {
                MessageBox.Show("There seems to have been some monkey business.  Try again!");
            }
            else 
            {
                try
                {
                    using (FileStream fs = File.Create(oSaveFileDialog.FileName))
                    {
                        for (int xPos = 0; xPos < iXSize; xPos++)
                        {
                            for (int yPos = 0; yPos < iYSize; yPos++)
                            {
                                var oThisJSONObject = new
                                {
                                    xPos = oMapArray[xPos, yPos].IXPos.ToString(),
                                    yPos = oMapArray[xPos, yPos].IYPos.ToString(),
                                    Image = oMapArray[xPos, yPos].SImage,
                                    OccupantID = oMapArray[xPos, yPos].IOccupantId.ToString(),                                    
                                };                                
                                byte[] oWriteThis = new UTF8Encoding(true).GetBytes(oThisJSONObject.ToString() + Environment.NewLine);
                                fs.Write(oWriteThis, 0, oWriteThis.Length);                               
                            }
                        };
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Monkey business happened when saving: " + ex.ToString());
                }

                MessageBox.Show("File saved");
            }
        }
    }
}
