using System;
using System.IO;
using System.Collections.Generic;

namespace Day02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Input.txt");

            // Test
            //Input = null;
            //Input = new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" };

            Dictionary<int, KeypadElement> Keypad = new Dictionary<int, KeypadElement>();

            for (int i = 1; i < 10; i++)
            {
                Keypad.Add(i, new KeypadElement(i));
            }

            Keypad[1].Right = Keypad[2];
            Keypad[1].Down = Keypad[4];
            Keypad[2].Right = Keypad[3];
            Keypad[2].Down = Keypad[5];
            Keypad[3].Down = Keypad[6];
            Keypad[4].Right = Keypad[5];
            Keypad[4].Down = Keypad[7];
            Keypad[5].Right = Keypad[6];
            Keypad[5].Down = Keypad[8];
            Keypad[6].Down = Keypad[9];
            Keypad[7].Right = Keypad[8];
            Keypad[8].Right = Keypad[9];


            string Code = "";
            KeypadElement StartElement = Keypad[5];;

            foreach (var Command in Input)
            {
                foreach (var Element in Command)
                {
                    switch (Element)
                    {
                        case 'U':
                            if (StartElement.Up != null)
                            {
                                StartElement = StartElement.Up;
                            }
                            break;
                        case 'R':
                            if (StartElement.Right != null)
                            {
                                StartElement = StartElement.Right;
                            }
                            break;
                        case 'D':
                            if (StartElement.Down != null)
                            {
                                StartElement = StartElement.Down;
                            }
                            break;
                        case 'L':
                            if (StartElement.Left != null)
                            {
                                StartElement = StartElement.Left;
                            }
                            break;
                        default:
                            break;
                    }
                }

                Code += StartElement.Value.ToString();
            }

            Console.WriteLine("Part1: "+ Code); // 53255
        }
    }
}
