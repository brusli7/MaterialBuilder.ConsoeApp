using System;

namespace Test.MaterialBuilders
{
    public class Rectangle : Material
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override void Output()
        {
            Console.WriteLine("Rectangle ({0},{1}) width={2} height={3}", Positions.X, Positions.Y, Width, Height);
        }

        public Rectangle(Position positions, int width, int height)
        {
            Positions = positions;
            Width = width;
            Height = height;
        }
    }
}
