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
        public Box() { }

        public int[,] getTable() { return table; }

        public void setPainted(bool isPainted)
        {
            painted = isPainted;
        }

        public bool getPainted() { return painted; }
    }
}
