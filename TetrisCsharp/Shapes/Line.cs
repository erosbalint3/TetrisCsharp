using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class Line : Shapes
    {
        private int[,,] rotations = new int[2, 4, 2]
        {
            {
                {1, 1},
                {2, 1},
                {3, 1},
                {4, 1}
            },
            {
                {1, 1},
                {1, 2},
                {1, 3},
                {1, 4}
            }
        };
        private int[,] table = new int[4, 2] 
        {
            {1, 1},
            {2, 1},
            {3, 1},
            {4, 1}
        };
        private int currentRotation = 0;
        private bool isPainted = false;

        public Line() { }

        public int[,] getTable() { return table; }

        public bool getPainted() { return isPainted; }

        public void Rotate()
        {
            if (currentRotation < 3)
            {
                currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            }
        }

        public void setPainted(bool isPainted) { this.isPainted = isPainted; }
    }
}
