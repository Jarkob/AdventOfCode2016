using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            Console.WriteLine("Part1: " + Part1(Input)); // 105
            Console.WriteLine("Part2: " + Part2(Input)); // 474 too high 262 too high too
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

            // Neue Strategie: Alle suchen, nach in und out aufteilen und dann vergleichen

            for (int i = 0; i < Input.Length; i++)
            {
                char LastBracket = ']';
                List<string> Inside = new List<string>();
                List<string> Outside = new List<string>();

                for (int j = 0; j < Input[i].Length - 2; j++)
                {
                    if (Input[i][j] == '[' || Input[i][j] == ']')
                    {
                        LastBracket = Input[i][j];
                        continue;
                    }

                    if (Input[i][j] == Input[i][j + 2]
                        && Input[i][j] != Input[i][j + 1]
                        && Input[i][j + 1] != ']'
                        && Input[i][j + 1] != '[')
                    {
                        if (LastBracket == ']')
                        {
                            Outside.Add(Input[i][j] + "" + Input[i][j + 1] + "" + Input[i][j + 2]);
                        }
                        else if (LastBracket == '[')
                        {
                            Inside.Add(Input[i][j] + "" + Input[i][j + 1] + "" + Input[i][j + 2]);
                        }
                    }
                }

                // Jetzt prüfen
                bool Found = false;
                for (int k = 0; k < Inside.Count && !Found; k++) {
                    for (int l = 0; l < Outside.Count && !Found; l++) {
                        if(Inside[k][0] == Outside[l][1] && Inside[k][1] == Outside[l][0]) {
                            Tls++;
                            Found = true;
                            break;
                        }
                    }
                }
            }



            return Tls;
        }
    }
}
