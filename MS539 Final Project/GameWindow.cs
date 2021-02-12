﻿// CWW
// MS539 Final Project
// Current functionality - this main game window opens and allows the user to randomize the map.  
// The only non-random factors are the castles in each corner.
// 
// menu items working: save (meets criteria for weekly goal)
// Exit/Quit
//
// Week 4: Added chat, enlarged map, added support for tile buttons to sense viable directions.
// Chat has a list of unnacceptable words that will be altered if entered.  

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
        public static int iXSize = 10;
        public static int iYSize = 7;
        public List<string> sColorList = new List<string> { "Green", "Yellow" };
        private System.Windows.Forms.SaveFileDialog oSaveFileDialog;
        public Chat oThisChat = new Chat();

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

        public void FinishTileButton(TileButton oThisTileButton)
        {
  
            oThisTileButton.BackColor = System.Drawing.Color.Transparent;            
            oThisTileButton.Size = new System.Drawing.Size(40, 40);
            oThisTileButton.Image = Image.FromFile(oThisTileButton.SImage);
            oThisTileButton.ImageAlign = ContentAlignment.TopLeft;
            oThisTileButton.TabStop = false;
            oThisTileButton.FlatStyle = FlatStyle.Flat;
            oThisTileButton.FlatAppearance.BorderSize = 0;
            oThisTileButton.Enabled = true;
            oThisTileButton.AutoSize = true;
            oThisTileButton.Margin = new Padding(0, 0, 0, 0);
            oThisTileButton.Padding = new Padding(0, 0, 0, 0);            
            oThisTileButton.IOccupantId = 0;
            oThisTileButton.Click += new EventHandler(Map_Click);
        }

        public TileButton NewRandomTile(int iXpos, int iYpos, string sColor)
        {
            string sImageName = "";
            TileButton oThisTileButton = new TileButton();
            bool bIsOutsideBounds = false;
            do
            {
                bIsOutsideBounds = false;
                oThisTileButton.Location = new System.Drawing.Point(12 + (iXpos * 40), 60 + (iYpos * 40));
                switch (_myRandom.Next(50) % 7)
                {
                    case 0:
                        sImageName = "L.BMP";
                        oThisTileButton.BNorthOpen = true;
                        oThisTileButton.BSouthOpen = false;
                        oThisTileButton.BEastOpen = true;
                        oThisTileButton.BWestOpen = false;
                        break;
                    case 1:
                        sImageName = "L2.BMP";
                        oThisTileButton.BNorthOpen = true;
                        oThisTileButton.BSouthOpen = false;
                        oThisTileButton.BEastOpen = false;
                        oThisTileButton.BWestOpen = true;
                        break;
                    case 2:
                        sImageName = "L3.BMP";
                        oThisTileButton.BNorthOpen = false;
                        oThisTileButton.BSouthOpen = true;
                        oThisTileButton.BEastOpen = false;
                        oThisTileButton.BWestOpen = true;
                        break;
                    case 3:
                        sImageName = "L4.BMP";
                        oThisTileButton.BNorthOpen = false;
                        oThisTileButton.BSouthOpen = true;
                        oThisTileButton.BEastOpen = true;
                        oThisTileButton.BWestOpen = false;
                        break;
                    case 4:
                        sImageName = "ntos.BMP";
                        oThisTileButton.BNorthOpen = true;
                        oThisTileButton.BSouthOpen = true;
                        oThisTileButton.BEastOpen = false;
                        oThisTileButton.BWestOpen = false;
                        break;
                    case 5:
                        sImageName = "etow.BMP";
                        oThisTileButton.BNorthOpen = false;
                        oThisTileButton.BSouthOpen = false;
                        oThisTileButton.BEastOpen = true;
                        oThisTileButton.BWestOpen = true;
                        break;
                    case 6:
                        sImageName = "solid.BMP";
                        oThisTileButton.BNorthOpen = false;
                        oThisTileButton.BSouthOpen = false;
                        oThisTileButton.BEastOpen = false;
                        oThisTileButton.BWestOpen = false;
                        break;
                }
                // catch the first and last items to ensure that they are castles
                if (((iXpos == 0) && (iYpos == 0)) || ((iXpos == (iXSize - 1)) && (iYpos == (iYSize - 1))))
                {
                    sImageName = "castle.bmp";
                    oThisTileButton.BNorthOpen = false;
                    oThisTileButton.BSouthOpen = false;
                    oThisTileButton.BEastOpen = false;
                    oThisTileButton.BWestOpen = false;
                }
                oThisTileButton.IXPos = iXpos + 1;
                oThisTileButton.IYPos = iYpos + 1;
                string sPath = @"..\..\Resources\Images\" + sColor + @"\" + sImageName;
                oThisTileButton.SImage = sPath;
                bIsOutsideBounds = Program.oGameCore.TileGoesOutOfBounds(oThisTileButton, iXSize, iYSize);
            } while (bIsOutsideBounds == false);
            
            return oThisTileButton;
        }
        private void Map_Click(object sender, EventArgs e)
        {
            TileButton oTB = (TileButton)sender;
            string sStats = "STATS";
            sStats += System.Environment.NewLine;
            sStats += "x: " + oTB.IXPos.ToString();
            sStats += System.Environment.NewLine;
            sStats += "y: " + oTB.IYPos.ToString();
            sStats += System.Environment.NewLine;
            sStats += "N: " + oTB.BNorthOpen.ToString();
            sStats += System.Environment.NewLine;
            sStats += "E: " + oTB.BEastOpen.ToString();
            sStats += System.Environment.NewLine;
            sStats += "S: " + oTB.BSouthOpen.ToString();
            sStats += System.Environment.NewLine;
            sStats += "W: " + oTB.BWestOpen.ToString();
            sStats += System.Environment.NewLine;
            sStats += "Image: " + oTB.SImage;
            MessageBox.Show(sStats);
        }

        public void drawMap()
        {            
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
            string sColor = "";
            sColor = mapColor();

            bool bIsViableMap = true;
            // need to develop a do while loop to ensure that the map can be path'd
            do
            {
                //unloadMap();
                for (int xPos = 0; xPos < iXSize; xPos++)
                {
                    for (int yPos = 0; yPos < iYSize; yPos++)
                    {
                        oMapArray[xPos, yPos] = NewRandomTile(xPos, yPos, sColor);
                    }
                }                
                if(Program.oGameCore.IsViableMap(oMapArray, iXSize, iYSize))
                {
                    bIsViableMap = false;
                }   else
                {
                    bIsViableMap = true;
                }          
            } while (bIsViableMap);
            for (int xPos = 0; xPos < iXSize; xPos++)
            {
                for (int yPos = 0; yPos < iYSize; yPos++)
                {
                    FinishTileButton(oMapArray[xPos, yPos]);
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

        public void sendButton_Click(object sender, EventArgs e)
        {
            string sThisText = this.chatInputTextBox.Text;
            this.chatInputTextBox.Text = "";
            if (sThisText.Length > 0)
            {
                this.chatRichTextBox.Text = oThisChat.AddChatLine(sThisText);
            }            
        }
    }
}
