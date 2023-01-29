﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace TetrisCsharp.Shapes
{
    internal class Shapes
    {
        public Shapes() { }

        protected void PrintShape(int[,] table)
        {
            for (int i = 0; i < table.Length / 2; i++)
            {
                for (int j = i; j < table.Length - i - 1; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        protected int[,] changeTable(int[,] table, int[,,] rotations, int rotationIndex)
        {
            int[,] temp = new int[4, 2];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    temp[i, j] = rotations[rotationIndex, i, j];
                }
            }
            return temp;
        }
    }
}
