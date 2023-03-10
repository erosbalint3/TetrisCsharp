using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class Box : Shapes
    {

        private int[,] table = new int[4, 2]
        {
            {1, 1},
            {1, 2},
            {2, 1},
            {2, 2}
        };
        private bool painted = false;
        private bool ableToMoveLeft = false;
        private bool ableToMoveRight = true;
        private bool atTheBottom = false;
        public Box() { }

        public override void Rotate()
        {
            
        }

        public override int[,] getTable() { return table; }

        public override void setPainted(bool isPainted)
        {
            painted = isPainted;
        }

        public override bool getPainted() { return painted; }

        public override void setAtTheBottom() { this.atTheBottom = true; }

        public override bool getAbleToMoveLeft() { return ableToMoveLeft; }
        public override bool getAbleToMoveRight() { return ableToMoveRight; }
        public override bool getAtTheBottom() { return atTheBottom; }
        public override void setAbleToMoveLeft(bool ableToMoveLeft) { this.ableToMoveLeft = ableToMoveLeft; }
        public override void setAbleToMoveRight(bool ableToMoveRight) { this.ableToMoveRight = ableToMoveRight; }
    }
}
