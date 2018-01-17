using System;
using System.Collections.Generic;
using Test.MaterialBuilders;

namespace Test
{
    class Program
    {        
        const int NU_OF_INPUTS = 1;

        public static void Main(string[] args)
        {                      
            List<string[]> matirialSpecification = Input();
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
                MyLogger.Log();
                Console.WriteLine("+++++Abort+++++");
            }
            Console.ReadKey();
        }

        //This method takes user input and returns a List of string  arrays
        //Example input: 1xr 10 10 30 40 enter.....
        public static List<string[]> Input()
        {
            Console.WriteLine("Plese input widget spec: ");
            string[] inputLines = new string[NU_OF_INPUTS];
            List<string[]> inputSpec = new List<string[]>();

            for (int i = 0; i < NU_OF_INPUTS; i++)
            {
                string input = Console.ReadLine();
                inputLines[i] = input;
            }
            
            for (int i = 0; i < inputLines.Length; i++)
            {
                inputSpec.Add(inputLines[i].Split(' '));                              
            }
            
            return inputSpec;
        }
   
        // This method takes input specification an creates new widgets 
        // and outputs them to the screen
        public static void Output(List<string[]> inputSpec)
        {
            foreach (var line in inputSpec)
            {               
                string typeOfMatirial = line[0];
                string code = typeOfMatirial.Substring(2).ToUpper();
                string newText = string.Empty;
                if (code.Equals("T"))
                {
                    for (int i = 5; i < line.Length; i++)
                    {
                     newText += line[i] + " ";
                    }
                }

                switch (code)
                {

                    case "R":
                        Rectangle r = new Rectangle(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]));
                        r.Output();
                        break;
                    case "S":
                        Square s = new Square(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));
                        s.Output();
                        break;
                    case "E":
                        Ellipse e = new Ellipse(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]));
                        e.Output();
                        break;
                    case "C":
                        Circle c = new Circle(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]));
                        c.Output();
                        break;
                    case "T":
                        Textbox t = new Textbox(new Position(int.Parse(line[1]), int.Parse(line[2])), int.Parse(line[3]), int.Parse(line[4]), newText);
                        t.Output();
                        break;
                    default:
                        break;
                }

            }


        }

        // This method validates if the input is negative or over 1000
        public static bool Validation(List<string[]> matirialSpec)
        {
            foreach (var line in matirialSpec)
            {
                int x;
                foreach (var spec in line)
                {
                    if (int.TryParse(spec, out x))
                    {
                        if ((int.Parse(spec) < 0) || (int.Parse(spec) >= 1000))
                        {
                            MyLogger.Log("exception with matirial for input " + spec + ", correct input should be between 0 - 1000");
                            return false;
                        }
                    }

                }
            }

            return true;
        }

    }
}
