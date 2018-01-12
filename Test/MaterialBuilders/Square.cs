using System;

namespace Test.MaterialBuilders
{
    public class Square : Material
    {
        public int Width { get; set; }

        public override void Output()
        {
            Console.WriteLine("Square ({0},{1}) size={2}", Positions.PositionX, Positions.PositionY, Width);
        }

        public Square(Position positions, int width)
        {
            Positions = positions;
            Width = width;
        }
    }
}
