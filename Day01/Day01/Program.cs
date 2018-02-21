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

            int Distance1 = Part1(Instructions);
            int Distance2 = Part2(Instructions);

            Console.WriteLine("Part1: " + Distance1); // 246
            Console.WriteLine("Part2: " + Distance2); // 124
        }


        private static int Part1(string[] Instructions)
        {
            // Set up moving
            int X = 0;
            int Y = 0;
            char Direction = 'n';
            char Turn;
            int Steps;

            foreach (var Instruction in Instructions)
            {
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
            return Math.Abs(X) + Math.Abs(Y);
        }


        public static int Part2(string[] Instructions)
        {
            // Set up moving
            int X = 0;
            int Y = 0;
            char Direction = 'n';
            char Turn;
            int Steps;
            List<(int, int)> Locations = new List<(int, int)>();
            Locations.Add((X, Y));

            foreach (var Instruction in Instructions)
            {
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
                        for (; Steps > 0; Steps--)
                        {
                            Y++;
                            if (Locations.Contains((X, Y)))
                            {
                                return Math.Abs(X) + Math.Abs(Y);
                            }
                            Locations.Add((X, Y));
                        }
                        break;
                    case 'o':
                        for (; Steps > 0; Steps--)
                        {
                            X++;
                            if (Locations.Contains((X, Y)))
                            {
                                return Math.Abs(X) + Math.Abs(Y);
                            }
                            Locations.Add((X, Y));
                        }
                        break;
                    case 's':
                        for (; Steps > 0; Steps--)
                        {
                            Y--;
                            if (Locations.Contains((X, Y)))
                            {
                                return Math.Abs(X) + Math.Abs(Y);
                            }
                            Locations.Add((X, Y));
                        }
                        break;
                    case 'w':
                        for (; Steps > 0; Steps--)
                        {
                            X--;
                            if (Locations.Contains((X, Y)))
                            {
                                return Math.Abs(X) + Math.Abs(Y);
                            }
                            Locations.Add((X, Y));
                        }
                        break;
                    default:
                        throw new Exception("Unknown direction: " + Direction);
                }
            }

            return -1;
        }
    }
}
