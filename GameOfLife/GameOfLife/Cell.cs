using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class 
        Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsAlive = true;
        }

        public int Y { get; set; }
        public int X { get; set; }
        public int Neighbours { get; set; }
        public bool IsAlive { get; set; }
    }
}
