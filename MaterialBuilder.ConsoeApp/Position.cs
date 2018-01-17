using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Position
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Position(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
