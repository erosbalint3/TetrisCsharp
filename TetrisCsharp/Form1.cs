using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCsharp.Shapes;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace TetrisCsharp
{
    public partial class Form1 : Form
    {
        private T l = new T();
        List<PictureBox> pictureBoxes;
        private int movingIndex = -1;
        private int rowMovingIndex = -1;
        private const char LEFT = 'a';
        private const char RIGHT = 'd';
        private const char ROTATE = 'w';
        public Form1()
        {
            
            InitializeComponent();
            timer1.Interval = 1000;
            pictureBoxes = tableLayoutPanel1.Controls.OfType<PictureBox>().ToList();
            pictureBoxes = pictureBoxes.Select(pBox => pBox).OrderBy(pBox => pBox.Name).ToList();
            timer1.Tick += new EventHandler(GameEventHandler);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void GameEventHandler(Object myObject, EventArgs myEvenyArgs)
        {
            if (Keyboard.IsKeyToggled(Key.Q))
            {
                timer1.Stop();
            }
            else
            {
                if (CheckIfNotOutsideOfBoundsAfterMoveDown())
                {
                    RefreshTileImages(l.getTable());
                    rowMovingIndex++;
                    PaintShape(l.getTable());
                } else
                {
                    
                    timer1.Stop();
                }
                
            }
        }

        private bool CheckIfNotOutsideOfBoundsAfterMoveDown()
        {
            int[] yCoordinates = new int[4];
            for (int i = 0; i < 4; i++)
            {
                yCoordinates[i] = l.getTable()[i, 0];
            }
            int biggestYCoordinate = yCoordinates.Max();
            if ( biggestYCoordinate + rowMovingIndex >= 19)
            {
                l.setAtTheBottom();
                return false;
            }
            return true;
        }

        //TODO: Rotation
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 36 && e.KeyChar <= 190)
            {

                switch (e.KeyChar)
                {
                    case LEFT:
                        MoveToLeft();
                        break;
                    case RIGHT:
                        MoveToRight();
                        break;
                    
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PaintShape(int[,] shape)
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                pictureBoxes[((shape[i, 0] + rowMovingIndex) * 10) + shape[i, 1] + movingIndex].Image = new Bitmap(@"tile2.png");               
            }
            tableLayoutPanel1.Refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (!l.getPainted()) {
                PaintShape(l.getTable());
                l.setPainted(true);
            }  
            l.setPainted(true);
        }

        private void MoveToRight()
        {
            CheckIfNotOutsideOfBoundsWhileMovingSideways();
            if (l.getAbleToMoveRight() && !l.getAtTheBottom())
            {
                RefreshTileImages(l.getTable());
                movingIndex++;
                PaintShape(l.getTable());
            }
        }

        private void MoveToLeft()
        {
            CheckIfNotOutsideOfBoundsWhileMovingSideways();
            if (l.getAbleToMoveLeft() && !l.getAtTheBottom())
            {
                RefreshTileImages(l.getTable());
                movingIndex--;
                PaintShape(l.getTable());
            }
        }

        private void RefreshTileImages(int[,] shape)
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                pictureBoxes[((shape[i, 0] + rowMovingIndex) * 10) + shape[i, 1] + movingIndex].Image = null;
            }
            tableLayoutPanel1.Refresh();
        }

        private void CheckIfNotOutsideOfBoundsWhileMovingSideways()
        {
            int[] xCoordinates = new int[4];
            for (int i = 0; i < 4; i++)
            {
                xCoordinates[i] = l.getTable()[i, 1];
            }
            int smallestCoordinate = xCoordinates.Min();
            int biggestCoordinate = xCoordinates.Max();
            if (smallestCoordinate + movingIndex < 1)
            {
                l.setAbleToMoveLeft(false);
            } else
            {
                l.setAbleToMoveLeft(true);
            }
            if (biggestCoordinate + movingIndex > 8)
            {
                l.setAbleToMoveRight(false);
            } else
            {
                l.setAbleToMoveRight(true);
            }
        }
    }
}
