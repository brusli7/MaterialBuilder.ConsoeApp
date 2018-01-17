using System;

namespace Test.MaterialBuilders
{
    public class Circle : Material
    {       
        public int Diameter { get; set; }

        public override void Output()
        {
            Console.WriteLine("Circle ({0},{1}) size={2}", Positions.PositionX, Positions.PositionY, Diameter);
        }

        public Circle(Position position, int diameter)
        {
            Positions = position;
            Diameter = diameter;
        }
    }
}
