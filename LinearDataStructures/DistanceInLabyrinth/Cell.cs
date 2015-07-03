using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceInLabyrinth
{
    internal struct Cell
    {
        public Cell(int x, int y, int value)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int Value { get; private set; }

        public int Y { get; private set; }

        public int X { get; private set; }
    }
}
