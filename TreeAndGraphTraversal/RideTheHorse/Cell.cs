using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideTheHorse
{
    struct Cell
    {
        public Cell(int x, int y, int value = 1)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int Y { get; set; }
        public int X { get; set; }
        public int Value { get; set; }
    }
}
