using System;

namespace Test.MaterialBuilders
{
    public class Textbox : Material
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }

        public override void Output()
        {
            Console.WriteLine("Textbox ({0},{1}) width={2} height={3} text={4}", Positions.X, Positions.Y, Width, Height, Text);
        }

        public Textbox(Position positions, int width, int height, string text)
        {
            Positions = positions;
            Width = width;
            Height = height;
            Text = text;
        }
    }
}
