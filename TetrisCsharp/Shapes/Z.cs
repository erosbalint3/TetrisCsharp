using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class Z : Shapes
    {
        private int[,,] rotations = new int[2, 4, 2]
        {
            {
                {1, 2},
                {1, 2},
                {2, 2},
                {2, 3}
            },
            {
                {1, 2},
                {2, 1},
                {2, 2},
                {3, 1}
            }
        };
        private int[,] table = new int[4, 2]
        {
            {1, 1},
            {1, 2},
            {2, 2},
            {2, 3}
        };
        private bool isPainted = false;
        private int currentRotation = 0;

        public Z() { }

        public int[,] getTable() { return table; }

        public bool getPainted() { return isPainted; }

        public void setPainted(bool isPainted) { this.isPainted = isPainted; }

        public void Rotate()
        {
            if (this.currentRotation < 1)
            {
                this.currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            }
        }
    }
}
