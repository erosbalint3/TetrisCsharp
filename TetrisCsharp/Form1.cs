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
using System.Drawing.Text;

namespace TetrisCsharp
{
    public partial class Form1 : Form
    {
        private Shapes.Shapes currentShape = new L();
        List<PictureBox> pictureBoxes;
        private int movingIndex = -1;
        private int rowMovingIndex = -1;
        private const char LEFT = 'a';
        private const char RIGHT = 'd';
        private const char ROTATE = 'w';
        private const char DOWN = 's';
        private Bitmap tile = new Bitmap(@"tile2.png");
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
                if (CheckIfBottomLineIsFull())
                {
                    DrawIfBottomLineIsFull();
                }
                if (CheckIfNotOutsideOfBoundsAfterMoveDown())
                {
                    RefreshTileImages(currentShape.getTable());
                    rowMovingIndex++;
                    PaintShape(currentShape.getTable());
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
                yCoordinates[i] = currentShape.getTable()[i, 0];
            }
            int biggestYCoordinate = yCoordinates.Max();
            if ( biggestYCoordinate + rowMovingIndex >= 19)
            {
                currentShape.setAtTheBottom();
                movingIndex = -1;
                rowMovingIndex = -1;
                GenerateRandomShape();
                return false;
            }
            return true;
        }

        private void GenerateRandomShape()
        {
            Random random = new Random();
            int randomShapeNumber = random.Next(0, 7);
            switch(randomShapeNumber)
            {
                case 0:
                    currentShape = new L();
                    break;
                case 1:
                    currentShape = new rL();
                    break;
                case 2:
                    currentShape = new Box();
                    break;
                case 3:
                    currentShape = new Line();
                    break;
                case 4:
                    currentShape = new S();
                    break;
                case 5:
                    currentShape = new Z();
                    break;
                case 6:
                    currentShape = new T();
                    break;
            }
            timer1 = new Timer();
            timer1.Tick += new EventHandler(GameEventHandler);
            timer1.Interval = 1000;
            timer1.Start();
            PaintShape(currentShape.getTable());
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
                    case ROTATE:
                        Rotate();
                        break;
                    case DOWN:
                        MoveDown();
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
                pictureBoxes[((shape[i, 0] + rowMovingIndex) * 10) + shape[i, 1] + movingIndex].Image = tile;               
            }
            tableLayoutPanel1.Refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (!currentShape.getPainted()) {
                PaintShape(currentShape.getTable());
                currentShape.setPainted(true);
            }  
            currentShape.setPainted(true);
        }

        private void MoveToRight()
        {
            CheckIfNotOutsideOfBoundsWhileMovingSideways();
            if (currentShape.getAbleToMoveRight() && !currentShape.getAtTheBottom())
            {
                RefreshTileImages(currentShape.getTable());
                movingIndex++;
                PaintShape(currentShape.getTable());
            }
        }

        private void MoveToLeft()
        {
            CheckIfNotOutsideOfBoundsWhileMovingSideways();
            if (currentShape.getAbleToMoveLeft() && !currentShape.getAtTheBottom())
            {
                RefreshTileImages(currentShape.getTable());
                movingIndex--;
                PaintShape(currentShape.getTable());
            }
        }

        private void Rotate()
        {
            if (!currentShape.getAtTheBottom())
            {
                RefreshTileImages(currentShape.getTable());
                currentShape.Rotate();
                PaintShape(currentShape.getTable());
            }
        }

        private void MoveDown()
        {
            if (!currentShape.getAtTheBottom())
            {
                RefreshTileImages(currentShape.getTable());
                rowMovingIndex++;
                PaintShape(currentShape.getTable());
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
                xCoordinates[i] = currentShape.getTable()[i, 1];
            }
            int smallestCoordinate = xCoordinates.Min();
            int biggestCoordinate = xCoordinates.Max();
            if (smallestCoordinate + movingIndex < 1)
            {
                currentShape.setAbleToMoveLeft(false);
            } else
            {
                currentShape.setAbleToMoveLeft(true);
            }
            if (biggestCoordinate + movingIndex > 8)
            {
                currentShape.setAbleToMoveRight(false);
            } else
            {
                currentShape.setAbleToMoveRight(true);
            }
        }

        private bool CheckIfBottomLineIsFull()
        {
            bool full = false;
            for (int i = 190; i < 200; i++)
            {
                if (pictureBoxes[i].Image == tile)
                {
                    full = true;
                } 
                else
                {
                    return false;
                }
            }
            return full;
        }

        private void DrawIfBottomLineIsFull()
        {
            for (int i = 190; i < 200; i++)
            {
                pictureBoxes[i].Image = null;
                tableLayoutPanel1.Refresh();
            }
            for (int i = 199; i > 9; i--)
            {
                if (pictureBoxes[i - 10].Image == tile)
                {
                    pictureBoxes[i].Image = tile;
                    pictureBoxes[i - 10].Image = null;
                }
            }
            tableLayoutPanel1.Refresh();
        }

        private void j2pictureBox93_Click(object sender, EventArgs e)
        {

        }
    }
}
