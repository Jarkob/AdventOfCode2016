using System;
using System.IO;
using System.Collections.Generic;

namespace Day06
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            Console.WriteLine("Part1: "+ Part1(Input)); // asvcbhvg
            Console.WriteLine("Part2: "+ Part2(Input)); // odqnikqv
        }


        public static string Part1(string[] Input)
        {
            char[] Message = new char[Input[0].Length];


            for (int i = 0; i < Input[0].Length; i++)
            {
                Dictionary<char, int> MostFrequentLetters = new Dictionary<char, int>();

                for (int j = 0; j < Input.Length; j++)
                {
                    if (MostFrequentLetters.ContainsKey(Input[j][i]))
                    {
                        MostFrequentLetters[Input[j][i]]++;
                    }
                    else
                    {
                        MostFrequentLetters.Add(Input[j][i], 1);
                    }
                }

                // Find biggest value
                KeyValuePair<char, int> MostFrequentLetter = new KeyValuePair<char, int>(' ', 0);
                foreach (var element in MostFrequentLetters)
                {
                    if (element.Value > MostFrequentLetter.Value)
                    {
                        MostFrequentLetter = element;
                    }
                }

                Message[i] = MostFrequentLetter.Key;
            }

            return new string(Message);
        }


        public static string Part2(string[] Input)
        {
            char[] Message = new char[Input[0].Length];


            for (int i = 0; i < Input[0].Length; i++)
            {
                Dictionary<char, int> MostFrequentLetters = new Dictionary<char, int>();

                for (int j = 0; j < Input.Length; j++)
                {
                    if (MostFrequentLetters.ContainsKey(Input[j][i]))
                    {
                        MostFrequentLetters[Input[j][i]]++;
                    }
                    else
                    {
                        MostFrequentLetters.Add(Input[j][i], 1);
                    }
                }

                // Find smallest value
                KeyValuePair<char, int> LeastFrequentLetter = new KeyValuePair<char, int>(' ', int.MaxValue);
                foreach (var element in MostFrequentLetters)
                {
                    if (element.Value < LeastFrequentLetter.Value)
                    {
                        LeastFrequentLetter = element;
                    }
                }

                Message[i] = LeastFrequentLetter.Key;
            }

            return new string(Message);
        }
    }
}
