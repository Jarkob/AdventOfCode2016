using System;
using System.IO;
using System.Collections.Generic;

namespace Day03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");
            string[][] FormattedInput = new string[Input.Length][];

            for (int i = 0; i < Input.Length; i++)
            {
                string[] Tmp = Input[i].Split(' ');

                List<string> Tmp2 = new List<string>();

                foreach (var element in Tmp)
                {
                    if (element != "")
                    {
                        Tmp2.Add(element);
                    }
                }

                FormattedInput[i] = Tmp2.ToArray();
            }

            int[][] Triangles = new int[Input.Length][];

            for (int i = 0; i < Input.Length; i++)
            {
                Triangles[i] = new int[] {
                    Convert.ToInt32(FormattedInput[i][0]),
                    Convert.ToInt32(FormattedInput[i][1]),
                    Convert.ToInt32(FormattedInput[i][2])
                };
            }

            int PossibleTriangles1 = 0;
            int PossibleTriangles2 = 0;

            for (int i = 0; i < Triangles.Length; i++)
            {
                if (
                    Triangles[i][0] + Triangles[i][1] > Triangles[i][2]
                    && Triangles[i][0] + Triangles[i][2] > Triangles[i][1]
                    && Triangles[i][1] + Triangles[i][2] > Triangles[i][0]
                )
                {
                    PossibleTriangles1++;
                }
            }

            for (int i = 0; i < Triangles.Length; i += 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (
                        Triangles[i][j] + Triangles[i + 1][j] > Triangles[i + 2][j]
                        && Triangles[i][j] + Triangles[i + 2][j] > Triangles[i + 1][j]
                        && Triangles[i + 1][j] + Triangles[i + 2][j] > Triangles[i][j]
                    )
                    {
                        PossibleTriangles2++;
                    }
                }
            }

            Console.WriteLine("Part1: " + PossibleTriangles1);// 917
            Console.WriteLine("Part2: " + PossibleTriangles2); // 1649
        }
    }
}
