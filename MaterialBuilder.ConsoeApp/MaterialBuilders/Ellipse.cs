using System;

namespace Test.MaterialBuilders
{
    public class Ellipse : Material
    {        
        public int HorizontalDiameter { get; set; }
        public int VerticalDiameter { get; set; }

        public override void Output()
        {
            Console.WriteLine("Ellipse ({0},{1}) diameterH = {2} diameterV = {3}", Positions.PositionX, Positions.PositionY, HorizontalDiameter, VerticalDiameter);
        }
        public Ellipse(Position positions, int hDiameter, int vDiameter)
        {
            Positions = positions;
            HorizontalDiameter = hDiameter;
            VerticalDiameter = vDiameter;
        }
    }
}
