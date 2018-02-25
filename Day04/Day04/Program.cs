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

            Console.WriteLine("Part1: " + Part1(Input)); // 278221
            Console.WriteLine("Part2: " + Part2(Input)); // 267
        }


        private static int Part1(string[] Input)
        {
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

                List<(char, int)> LetterFrequenciesSortedList = new List<(char, int)>();
                while (LetterFrequenciesList.Count > 0)
                {
                    (char, int) TallestElement = LetterFrequenciesList[0];
                    for (int j = 1; j < LetterFrequenciesList.Count; j++)
                    {
                        if (LetterFrequenciesList[j].Item2 > TallestElement.Item2)
                        {
                            TallestElement = LetterFrequenciesList[j];
                        }
                    }

                    LetterFrequenciesList.Remove(TallestElement);
                    LetterFrequenciesSortedList.Add(TallestElement);
                }


                // 5 größten auswählen
                char[] MostFrequent = new char[5];
                for (int i = 0; i < MostFrequent.Length; i++)
                {
                    MostFrequent[i] = LetterFrequenciesSortedList[i].Item1;
                }

                // Mit Prüfsumme vergleichen
                string Result = new string(MostFrequent);

                if (Result == Parts[Parts.Length - 1].Split('[')[1].Split(']')[0])
                {
                    // Hinzufügen
                    Sum += Convert.ToInt32(Parts[Parts.Length - 1].Split('[')[0]);
                }
            }

            return Sum;
        }


        private static int Part2(string[] Input)
        {
            //List<string> RealRooms = new List<string>();

            //// Filter decoys first
            //foreach (var element in Input)
            //{
            //    // Check if room is real
            //    string[] Parts = element.Split('-');

            //    // Find 5 most frequently used letters
            //    Dictionary<char, int> LetterFrequencies = new Dictionary<char, int>();

            //    for (int i = 0; i < Parts.Length - 1; i++)
            //    {
            //        foreach (var letter in Parts[i])
            //        {
            //            if (LetterFrequencies.ContainsKey(letter))
            //            {
            //                LetterFrequencies[letter]++;
            //            }
            //            else
            //            {
            //                LetterFrequencies.Add(letter, 0);
            //            }
            //        }
            //    }

            //    (char, int)[] FrequentNumbers = new(char, int)[5];
            //    for (int i = 0; i < 5; i++)
            //    {
            //        FrequentNumbers[i] = (' ', 0);
            //    }

            //    // Kompliziert weil nur 5 größten
            //    List<(char, int)> LetterFrequenciesList = new List<(char, int)>();
            //    foreach (var LetterFrequency in LetterFrequencies)
            //    {
            //        LetterFrequenciesList.Add((LetterFrequency.Key, LetterFrequency.Value));
            //    }

            //    // Funktioniert nicht
            //    LetterFrequenciesList.Sort();

            //    List<(char, int)> LetterFrequenciesSortedList = new List<(char, int)>();
            //    while (LetterFrequenciesList.Count > 0)
            //    {
            //        (char, int) TallestElement = LetterFrequenciesList[0];
            //        for (int j = 1; j < LetterFrequenciesList.Count; j++)
            //        {
            //            if (LetterFrequenciesList[j].Item2 > TallestElement.Item2)
            //            {
            //                TallestElement = LetterFrequenciesList[j];
            //            }
            //        }

            //        LetterFrequenciesList.Remove(TallestElement);
            //        LetterFrequenciesSortedList.Add(TallestElement);
            //    }


            //    // 5 größten auswählen
            //    char[] MostFrequent = new char[5];
            //    for (int i = 0; i < MostFrequent.Length; i++)
            //    {
            //        MostFrequent[i] = LetterFrequenciesSortedList[i].Item1;
            //    }

            //    // Mit Prüfsumme vergleichen
            //    string Result = new string(MostFrequent);

            //    if (Result == Parts[Parts.Length - 1].Split('[')[1].Split(']')[0])
            //    {
            //        // Hinzufügen
            //        RealRooms.Add(element);
            //    }
            //}

            foreach (var element in Input)
            {
                string[] Parts = element.Split('-');

                string Encrypted = "";
                for (int i = 0; i < Parts.Length - 1; i++)
                {
                    Encrypted += Parts[i] + "-";
                }
                Encrypted = Encrypted.Substring(0, Encrypted.Length - 1);

                int RoomNumber = Convert.ToInt32(Parts[Parts.Length - 1].Split('[')[0]);

                // Decrypt
                string Decrypted = "";

                foreach (var Letter in Encrypted)
                {
                    char TmpLetter = Letter;
                    for (int i = 0; i < RoomNumber; i++)
                    {
                        switch (TmpLetter)
                        {
                            case ' ':
                                break;
                            case '-':
                                TmpLetter = ' ';
                                break;
                            case 'z':
                                TmpLetter = 'a';
                                break;
                            default:
                                TmpLetter = (char)(TmpLetter + 1);
                                break;
                        }
                    }

                    Decrypted += TmpLetter;
                }

                if (Decrypted.Contains("north") || Decrypted == "northpole object storage")
                {
                    return RoomNumber;
                }
            }

            return -1;
        }
    }
}
