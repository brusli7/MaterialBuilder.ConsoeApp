using System;
using Test.MaterialBuilders;

namespace Test
{
    public class MaterialFactory
    {
        public static Material Create(int materialCount, string materialType,string[] line)
        {
            string newText = string.Empty;
            if (materialType.Equals("T"))
            {
                for (int i = 5; i < line.Length; i++)
                {
                newText += line[i] + " ";
                }
            }
                switch (materialType)
            {

                case "R":
                    return new Rectangle(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]));
                    
                    
                case "S":
                    return new Square(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));
                    
                   
                case "E":
                    return new Ellipse(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]));
                    
                    
                case "C":
                    return new Circle(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));
                    
                    
                case "T":
                    return new Textbox(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]), newText);
                    
                    
                default:
                    return null;
            }
        }
    }
}