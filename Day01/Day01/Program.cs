using System;
using System.IO;
using System.Collections.Generic;

namespace Day01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Get Input
            string Input = File.ReadAllText("../../Input.txt");
            string[] Instructions = Input.Split(',');
            for (int i = 0; i < Instructions.Length; i++)
            {
                Instructions[i] = Instructions[i].Trim();
            }


            // Set up moving
            int X = 0;
            int Y = 0;
            char Direction = 'n';
            char Turn;
            int Steps;
            int Distance1 = -1;
            int Distance2 = -1;
            List<(int, int)> Locations = new List<(int, int)>();

            foreach (var Instruction in Instructions)
            {
                if (Distance2 == -1)
                {
                    // Check if location exists
                    foreach (var Location in Locations)
                    {
                        if (Location.Item1 == X && Location.Item2 == Y)
                        {
                            Distance2 = Math.Abs(X) + Math.Abs(Y);
                            break;
                        }
                    }

                    // Add location
                    Locations.Add((X, Y));
                }
                
                Turn = Instruction[0];
                Steps = Convert.ToInt32(Instruction.Substring(1));

                // Change direction
                switch (Direction)
                {
                    case 'n':
                        if (Turn == 'R')
                        {
                            Direction = 'o';
                        }
                        else
                        { // Turn == 'L'
                            Direction = 'w';
                        }
                        break;
                    case 'o':
                        if (Turn == 'R')
                        {
                            Direction = 's';
                        }
                        else
                        { // Turn == 'L'
                            Direction = 'n';
                        }
                        break;
                    case 's':
                        if (Turn == 'R')
                        {
                            Direction = 'w';
                        }
                        else
                        { // Turn == 'L'
                            Direction = 'o';
                        }
                        break;
                    case 'w':
                        if (Turn == 'R')
                        {
                            Direction = 'n';
                        }
                        else
                        { // Turn == 'L'
                            Direction = 's';
                        }
                        break;
                    default:
                        throw new Exception("Unknown direction: " + Direction);
                }

                // Take steps
                switch (Direction)
                {
                    case 'n':
                        Y += Steps;
                        break;
                    case 'o':
                        X += Steps;
                        break;
                    case 's':
                        Y -= Steps;
                        break;
                    case 'w':
                        X -= Steps;
                        break;
                    default:
                        throw new Exception("Unknown direction: " + Direction);
                }
            }

            // Calculate distance
            Distance1 = Math.Abs(X) + Math.Abs(Y);

            Console.WriteLine("Part1: " + Distance1); // 246
            Console.WriteLine("Part2: "+ Distance2);
        }
    }
}
