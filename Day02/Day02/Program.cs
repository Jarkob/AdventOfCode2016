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

            Console.WriteLine("Part1: " + Part1(Input)); // 53255
            Console.WriteLine("Part2: " + Part2(Input)); // 7423A
        }


        private static string Part1(string[] Input)
        {
            Dictionary<char, KeypadElement> Keypad = new Dictionary<char, KeypadElement>();

            for (int i = 1; i < 10; i++)
            {
                Keypad.Add(i.ToString()[0], new KeypadElement(i.ToString()[0]));
            }

            Keypad['1'].Right = Keypad['2'];
            Keypad['1'].Down = Keypad['4'];
            Keypad['2'].Right = Keypad['3'];
            Keypad['2'].Down = Keypad['5'];
            Keypad['3'].Down = Keypad['6'];
            Keypad['4'].Right = Keypad['5'];
            Keypad['4'].Down = Keypad['7'];
            Keypad['5'].Right = Keypad['6'];
            Keypad['5'].Down = Keypad['8'];
            Keypad['6'].Down = Keypad['9'];
            Keypad['7'].Right = Keypad['8'];
            Keypad['8'].Right = Keypad['9'];


            string Code = "";
            KeypadElement StartElement = Keypad['5'];

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

            return Code;
        }


        private static string Part2(string[] Input)
        {
            Dictionary<char, KeypadElement> Keypad = new Dictionary<char, KeypadElement>();

            for (int i = 1; i < 10; i++)
            {
                Keypad.Add(i.ToString()[0], new KeypadElement(i.ToString()[0]));
            }

            Keypad.Add('A', new KeypadElement('A'));
            Keypad.Add('B', new KeypadElement('B'));
            Keypad.Add('C', new KeypadElement('C'));
            Keypad.Add('D', new KeypadElement('D'));

            Keypad['1'].Down = Keypad['3'];

            Keypad['2'].Down = Keypad['6'];
            Keypad['2'].Right = Keypad['3'];

            Keypad['3'].Down = Keypad['7'];
            Keypad['3'].Right = Keypad['4'];

            Keypad['4'].Down = Keypad['8'];

            Keypad['5'].Right = Keypad['6'];

            Keypad['6'].Down = Keypad['A'];
            Keypad['6'].Right = Keypad['7'];

            Keypad['7'].Down = Keypad['B'];
            Keypad['7'].Right = Keypad['8'];

            Keypad['8'].Down = Keypad['C'];
            Keypad['8'].Right = Keypad['9'];

            Keypad['A'].Right = Keypad['B'];

            Keypad['B'].Down = Keypad['D'];
            Keypad['B'].Right = Keypad['C'];

            string Code = "";
            KeypadElement StartElement = Keypad['5'];

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

            return Code;
        }
    }
}
