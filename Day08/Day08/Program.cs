using System;
using System.IO;

namespace Day08
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            // Test
            Input = null;
            Input = new string[] { "rect 3x2" };

            // Data structure for 50px wide, 6px high screen with bool values
            int Width = 50;
            int Height = 6;

            bool[][] Screen = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                Screen[i] = new bool[Width];
            }

            PrintScreen(Screen);

            // Execute commands
            string Command;
            int A;
            int B;

            foreach(var Line in Input)
            {
                Command = Line.Split(' ')[0];

                switch(Command) {
                    case "rect":
                        // Get A and B
                        A = (int)Char.GetNumericValue(Line.Split(' ')[1][0]);
                        B = (int)Char.GetNumericValue(Line.Split(' ')[1][2]);

                        for (int i = 0; i < B; i++) {
                            for (int j = 0; j < A; j++) {
                                Screen[i][j] = true;
                            }
                        }
                        break;
                    case "rotate":
                        Command = Line.Split(' ')[1];

                        switch(Command) {
                            case "row":
                                // Get A and B
                                A = (int)Char.GetNumericValue(Line.Split(' ')[2][2]);
                                B = (int)Char.GetNumericValue(Line.Split(' ')[4][0]);
                                // Wird so nicht gehen, siehe Fall A oder B >= 10
                                break;
                            case "column":
                                // Get A and B
                                break;
                            default:
                                throw new Exception("Unknown command: " + Command);
                        }
                        break;
                    default:
                        throw new Exception("Unknown command: " + Command);
                }
            }

            PrintScreen(Screen);
        }


        public static void PrintScreen(bool[][] Screen)
        {
            foreach(var Row in Screen)
            {
                foreach (var Pixel in Row)
                {
                    Console.Write(Pixel ? "#" : ".");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
