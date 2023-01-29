using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class L : Shapes
    {
        private int[,,] rotations = new int[4, 4, 2]
        {
            {
                {1, 1 },
                {2, 1 },
                {3, 1 },
                {3, 2 }
            },
            {
                {1, 3 },
                {2, 1 },
                {2, 2 },
                {2, 3 }
            },
            {
                {1, 1 },
                {1, 2 },
                {2, 2 },
                {3, 2 }
            },
            {
                {1, 1 },
                {1, 2 },
                {1, 3 },
                {2, 1 }
            }
        };
        private int[,] table = new int[4, 2] {
            {1, 1 },
            {2, 1 },
            {3, 1 },
            {3, 2 }
        };
        private int currentRotation = 0;
        private bool painted = false;

        public L() { }

        public void Rotate()
        {
            if (currentRotation < 3)
            {
                currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            }
        }

        public void Print()
        {
            this.PrintShape(this.table);
        }

        public int[,] getTable()
        {
            return this.table;
        }

        public bool getPainted()
        {
            return this.painted;
        }

        public void setPainted(bool painted)
        {
            this.painted = painted;
        }
    }
}
