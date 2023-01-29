using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class rL : Shapes
    {
        private int[,,] rotations = new int[4, 4, 2]
        {
            {
                {1, 2},
                {2, 2},
                {3, 2},
                {3, 1}
            },
            {
                {1, 1 },
                {1, 2 },
                {1, 3 },
                {2, 3 }
            },
            {
                {1, 1 },
                {1, 2 },
                {2, 1 },
                {3, 1 }
            },
            {
                {1, 1 },
                {2, 1 },
                {2, 2 },
                {2, 3 }
            }
        };
        private int[,] table = new int[4, 2]
        {
            {1, 2},
            {2, 2},
            {3, 2},
            {3, 1}
        };
        private int currentRotation = 0;
        private bool isPainted = false;

        public rL() { }

        public int[,] getTable()
        {
            return table;
        }

        public bool getPainted()
        {
            return isPainted;
        }

        public void setPainted(bool isPainted)
        {
            this.isPainted = isPainted;
        }

        public void Rotate()
        {
            if (currentRotation < 3)
            {
                currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            }
        }
    }
}
