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

            Console.WriteLine("Part1: "+ new string(Message)); // asvcbhvg
        }
    }
}
