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

            // Test
            Input = null;
            Input = new string[] {
                "aaaaa-bbb-z-y-x-123[abxyz]",
                "a-b-c-d-e-f-g-h-987[abcde]",
                "not-a-real-room-404[oarel]",
                "totally-real-room-200[decoy]"
            };

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
                List<(char, int)> LetterFrequenciesList = new List<(char, int)>();
                foreach (var LetterFrequency in LetterFrequencies)
                {
                    LetterFrequenciesList.Add((LetterFrequency.Key, LetterFrequency.Value));
                }

                // Funktioniert nicht
                LetterFrequenciesList.Sort();

                // 5 größten auswählen
                char[] MostFrequent = new char[5];
                for (int i = 0; i < MostFrequent.Length; i++)
                {
                    MostFrequent[i] = LetterFrequenciesList[i].Item1;
                }

                // Mit Prüfsumme vergleichen
                string Result = new string(MostFrequent);
                Console.WriteLine(Result);
                Console.WriteLine(Parts[Parts.Length - 1].Split('[')[1].Split(']')[0]);
                if (Result == Parts[Parts.Length - 1].Split('[')[1].Split(']')[0])
                {
                    // Hinzufügen
                    Sum += Convert.ToInt32(Parts[Parts.Length - 1].Split('[')[0]);
                }
            }

            Console.WriteLine("Part1: " + Sum);
        }
    }
}
