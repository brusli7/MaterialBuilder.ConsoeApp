using System;
using System.Collections.Generic;
using Test.MaterialBuilders;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    class Program
    {        
        const int NU_OF_INPUTS = 1;

        public static void Main(string[] args)
        {                      
            List<Material> matirialSpecification = Input();
            if (Validation(matirialSpecification))
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Bill of Materials");
                Console.WriteLine("----------------------------------------------------------------");
                Output(matirialSpecification);
                Console.WriteLine("----------------------------------------------------------------");
            }
            else
            {
                MaterialLogger.Log();
                Console.WriteLine("+++++Abort+++++");
            }
            Console.ReadKey();
        }

        //This method takes user input and returns a List of string  arrays
        //Example input: 1xr 10 10 30 40 enter.....
        public static List<Material> Input()
        {
            Console.WriteLine("Plese input widget spec: ");
            string line = string.Empty;
            List<Material> materials = new List<Material>();
            
            while (!(line.Equals("END")))
            {
                int materialCount;
                string materialType;
                string[] materialCountAndType;
                string[] specLine;
                line = Console.ReadLine();
                if (!(line.Equals("END")))
                {
                    if (ValidationOfSpace(line))
                    {
                        specLine = line.Split(' ');
                        if (ValidateFormat(specLine[0]))
                        {
                            materialCountAndType = specLine[0].Split('x');
                            materialCount = int.Parse(materialCountAndType[0]);
                            materialType = materialCountAndType[1].ToUpper();
                            materials.Add(MaterialFactory.Create(materialCount, materialType, specLine));
                        }
                        else
                        {
                            try
                            {
                                Exception e = new Exception();
                                throw e;
                            }
                            catch (Exception)
                            {
                                MaterialLogger.Log("Wrong input formt!!");
                                Console.WriteLine("+++++Abort+++++");
                                Console.ReadKey();
                                Environment.Exit(1);
                            }

                        }
                    }
                }
                else
                {
                    break;
                }                              
            }
            return materials;
           
        }
   
        // This method takes input specification an creates new widgets 
        // and outputs them to the screen
        public static void Output(List<Material> inputSpec)
        {
            foreach (var item in inputSpec)
            {
                item.Output();
            }
        }

        //This method validates if the input is negative or over 1000
        public static bool Validation(List<Material> matirialSpec)
        {
            foreach (var line in matirialSpec)
            {
                Textbox textBox;
                Square square;
                Rectangle rectangle;
                Circle circle;
                Ellipse ellipse;
                if (line.Positions.X >= 1000 || line.Positions.Y >= 1000)
                {
                    return false;
                }
                else if (line is Textbox)
                {
                    textBox = line as Textbox;
                    if(textBox.Height < 0 || textBox.Width < 0)
                    {
                        return false;
                    }
                }
                else if (line is Square)
                {
                    square = line as Square;
                    if (square.Width < 0)
                    {
                        return false;
                    }
                }
                else if (line is Rectangle)
                {
                    rectangle = line as Rectangle;
                    if (rectangle.Height < 0 || rectangle.Width < 0)
                    {
                        return false;
                    }
                }
                else if (line is Circle)
                {
                    circle = line as Circle;
                    if (circle.Diameter < 0)
                    {
                        return false;
                    }
                }
                else if (line is Ellipse)
                {
                    ellipse = line as Ellipse;                    
                    if (ellipse.HorizontalDiameter < 0 || ellipse.VerticalDiameter < 0)
                    {
                        return false;
                    }
                }       
            }
            return true;
        }

        public static bool ValidationOfSpace(string line)
        {
            if (line.Contains(" "))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateFormat(string str)
        {
            Regex pattern = new Regex(@"^\d{1}x[a-zA-Z]$");
            return pattern.IsMatch(str);
        }

    }
}
