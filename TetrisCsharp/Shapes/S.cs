﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCsharp.Shapes
{
    internal class S : Shapes
    {
        private int[,,] rotations = new int[2, 4, 2]
        {
            {
                {1, 2},
                {1, 3},
                {2, 1},
                {2, 2}
            },
            {
                {1, 1},
                {2, 1},
                {2, 2},
                {3, 2}
            }
        };
        private int[,] table = new int[4, 2]
        {
            {1, 2},
            {1, 3},
            {2, 1},
            {2, 2}
        };
        private int currentRotation = 0;
        private bool isPainted = false;

        public S()
        {

        }

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
            if (currentRotation < 1)
            {
                currentRotation++;
                table = changeTable(table, rotations, currentRotation);
            }
        }
    }
}