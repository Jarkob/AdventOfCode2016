using System;
using System.IO;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            int Tls = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length - 3; j++)
                {
                    if (Input[i][j] == Input[i][j + 3] && Input[i][j + 1] == Input[i][j + 2]
                        && Input[i][j] != ' ' && Input[i][j + 1] != ' ' && Input[i][j] != Input[i][j + 1])
                    {
                        Tls++;
                        break;
                    }
                }
            }

            Console.WriteLine("Part1: " + Tls);
        }
    }
}
