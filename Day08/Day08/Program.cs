using System;
using System.IO;

namespace Day08
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            int Width = 50;
            int Height = 6;

            bool[][] Screen = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                Screen[i] = new bool[Width];
            }

            string Command;
            int A;
            int B;

            foreach (var Line in Input)
            {
                Command = Line.Split(' ')[0];

                switch (Command)
                {
                    case "rect":
                        // Get A and B
                        A = Convert.ToInt32(Line.Split(' ')[1].Split('x')[0]);
                        B = Convert.ToInt32(Line.Split(' ')[1].Split('x')[1]);

                        for (int i = 0; i < B; i++)
                        {
                            for (int j = 0; j < A; j++)
                            {
                                Screen[i][j] = true;
                            }
                        }
                        break;
                    case "rotate":
                        Command = Line.Split(' ')[1];

                        // Get A and B
                        A = Convert.ToInt32(Line.Split(' ')[2].Split('=')[1]);
                        B = Convert.ToInt32(Line.Split(' ')[4]);

                        switch (Command)
                        {
                            case "row":
                                RotateRow(ref Screen, A, B);
                                break;
                            case "column":
                                RotateColumn(ref Screen, A, B);
                                break;
                            default:
                                throw new Exception("Unknown command: " + Command);
                        }
                        break;
                    default:
                        throw new Exception("Unknown command: " + Command);
                }
            }

            Console.WriteLine("Part1: "+ GetLitPixels(Screen)); // 121

            Console.WriteLine("Part2: ");
            PrintScreen(Screen); // RURUCEOEIL
        }


        public static void RotateRow(ref bool[][] Screen, int A, int B)
        {
            bool Swap;

            for (int i = 0; i < B; i++)
            {
                Swap = Screen[A][Screen[A].Length - 1];
                Screen[A][Screen[A].Length - 1] = Screen[A][0];
                Screen[A][0] = Swap;

                for (int j = Screen[A].Length - 1; j > 1; j--)
                {
                    Swap = Screen[A][j];
                    Screen[A][j] = Screen[A][j - 1];
                    Screen[A][j - 1] = Swap;
                }
            }
        }


        public static void RotateColumn(ref bool[][] Screen, int A, int B)
        {
            bool Swap;

            for (int i = 0; i < B; i++)
            {
                Swap = Screen[Screen.Length - 1][A];
                Screen[Screen.Length - 1][A] = Screen[0][A];
                Screen[0][A] = Swap;

                for (int j = Screen.Length - 1; j > 1; j--)
                {
                    Swap = Screen[j][A];
                    Screen[j][A] = Screen[j - 1][A];
                    Screen[j - 1][A] = Swap;
                }
            }
        }


        public static int GetLitPixels(bool[][] Screen)
        {
            int LitPixels = 0;

            foreach (var Row in Screen)
            {
                foreach (var Pixel in Row)
                {
                    if (Pixel) { LitPixels++; }
                }
            }

            return LitPixels;
        }


        public static void PrintScreen(bool[][] Screen)
        {
            foreach (var Row in Screen)
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
