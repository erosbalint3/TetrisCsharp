using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class T : Shapes
    {
        private int[,,] rotations = new int[4, 4, 2]
        {
            {
                {1, 2},
                {2, 1},
                {2, 2},
                {2, 3}
            },
            {
                {1, 1},
                {2, 1},
                {2, 2},
                {3, 1}
            },
            {
                {1, 1},
                {1, 2},
                {1, 3},
                {2, 2}
            },
            {
                {1, 2},
                {2, 1},
                {2, 2},
                {3, 2}
            }
        };
        private int[,] table = new int[4, 2]
        {
            {1, 2},
            {2, 1},
            {2, 2},
            {2, 3}
        };
        private int currentRotation = 0;
        private bool isPainted = false;
        private bool ableToMoveLeft = false;
        private bool ableToMoveRight = true;
        private bool atTheBottom = false;

        public T() { }

        public override int[,] getTable() { return table; }

        public override bool getPainted() { return isPainted; }

        public override void setPainted(bool isPainted) { this.isPainted = isPainted; }

        public override void Rotate()
        {
            if (currentRotation < 3)
            {
                currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            } else
            {
                currentRotation = -1;
                Rotate();
            }
        }

        public override bool getAbleToMoveLeft() { return ableToMoveLeft; }

        public override bool getAbleToMoveRight() { return ableToMoveRight; }

        public override void setAbleToMoveLeft(bool ableToMoveLeft) { this.ableToMoveLeft = ableToMoveLeft; }

        public override void setAbleToMoveRight(bool ableToMoveRight) { this.ableToMoveRight = ableToMoveRight; }

        public override bool getAtTheBottom() { return atTheBottom; }

        public override void setAtTheBottom() { this.atTheBottom = true; }
    }
}
