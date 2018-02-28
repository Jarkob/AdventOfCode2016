using System;
using System.IO;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            // Test
            Input = null;
            Input = new string[] { "aba[bab]xyz" };

            Console.WriteLine("Part1: " + Part1(Input)); // 105
            Console.WriteLine("Part2: " + Part2(Input));
        }


        public static int Part1(string[] Input)
        {
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

            return Tls;
        }


        public static int Part2(string[] Input)
        {
            int Tls = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length - 3; j++)
                {
                    if (Input[i][j] == ']' || Input[i][j] == '[')
                    {
                        continue;
                    }

                    if (Input[i][j] == Input[i][j + 2] && Input[i][j + 1] != Input[i][j]
                        && Input[i][j] != ']' && Input[i][j + 1] != ']' && Input[i][j] != '[' && Input[i][j + 1] != '[')
                    {
                        // Alle anderen 3er Sequenzen testen
                        for (int k = j + 3; k < Input[i].Length; k++)
                        {
                            if (Input[i][k] == Input[i][j]
                                && Input[i][k + 1] == Input[i][j + 1]
                                && Input[i][k + 2] == Input[i][j])
                            {
                                Tls++;
                            }
                        }
                    }
                }
            }

            return Tls; // noch nicht fertig
        }
    }
}
