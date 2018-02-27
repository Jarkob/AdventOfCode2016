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
                char LastBracket = ']';
                bool InsideBrackets = false;
                bool OutsideBrackets = false;

                for (int j = 0; j < Input[i].Length - 3; j++)
                {
                    if (Input[i][j] == ']' || Input[i][j] == '[')
                    {
                        LastBracket = Input[i][j];
                        continue;
                    }

                    if (Input[i][j] == Input[i][j + 3] && Input[i][j + 1] == Input[i][j + 2]
                        && Input[i][j] != ']' && Input[i][j + 1] != ']' && Input[i][j] != '[' && Input[i][j + 1] != '[' && Input[i][j] != Input[i][j + 1])
                    {
                        if (LastBracket == '[')
                        {
                            InsideBrackets = true;
                            break;
                        }
                        else if (LastBracket == ']')
                        {
                            OutsideBrackets = true;
                        }
                    }
                }

                if (!InsideBrackets && OutsideBrackets)
                {
                    Tls++;
                }
            }

            Console.WriteLine("Part1: " + Tls); // 105
        }
    }
}
