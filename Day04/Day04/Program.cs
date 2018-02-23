using System;
using System.IO;
using System.Collections.Generic;

namespace Day04
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            int Sum = 0;

            foreach (var element in Input)
            {
                // Check if room is real
                string[] Parts = element.Split('-');

                // Find 5 most frequently used letters
                Dictionary<char, int> LetterFrequencies = new Dictionary<char, int>();

                for (int i = 0; i < Parts.Length - 1; i++)
                {
                    foreach (var letter in Parts[i])
                    {
                        if (LetterFrequencies.ContainsKey(letter))
                        {
                            LetterFrequencies[letter]++;
                        }
                        else
                        {
                            LetterFrequencies.Add(letter, 0);
                        }
                    }
                }

                (char, int)[] FrequentNumbers = new(char, int)[5];
                for (int i = 0; i < 5; i++)
                {
                    FrequentNumbers[i] = (' ', 0);
                }

                // Kompliziert weil nur 5 größten
            }
        }
    }
}
