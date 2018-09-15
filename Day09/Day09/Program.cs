using System;
using System.IO;

namespace Day09
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string Input = File.ReadAllText("../../Input.txt");
            
            // debug
            //Input = "A(2x2)BCD(2x2)EFG";
            
            string Decompressed = "";
            string Command = "";
            string[] CommandParts;
            int Next;
            int Repeat;
            string Sequence = "";
            
            for (int i = 0, n = Input.Length; i < n; i++)
            {
                if (Input[i] == '(')
                {
                    // read parenthesis
                    i++;
                    for (; Input[i] != ')'; i++)
                    {
                        Command += Input[i];
                    }
                    
                    // process command
                    CommandParts = null;
                    CommandParts = Command.Split('x');
                    Next = Convert.ToInt32(CommandParts[0]);
                    Repeat = Convert.ToInt32(CommandParts[1]);
                    
                    Sequence = Input.Substring(i + 1, Next);
                    for (int j = 0; j < Repeat; j++)
                    {
                        Decompressed += Sequence;
                    }
                    
                    // move i forward
                    i += Next;
                    
                    // reset variables
                    Sequence = "";
                    Command = "";
                }
                else
                {
                    Decompressed += Input[i];
                }
            }
            
            Console.WriteLine("Part1: {0}", Decompressed.Length);
            // 74532

        }

        public static void Part2()
        {
            string Input = File.ReadAllText("../../Input.txt");

            long Length = GetDecompressedLength(Input);

            Console.WriteLine("Part2: {0}", Length);
            // 11558231665
        }

        public static long GetDecompressedLength(string Compressed)
        {
            long Length = 0;

            string Command = "";
            string[] CommandParts;
            int Next;
            int Repeat;
            string Sequence = "";

            for (int i = 0, n = Compressed.Length; i < n; i++)
            {
                if (Compressed[i] == '(')
                {
                    // read parenthesis
                    i++;
                    for (; Compressed[i] != ')'; i++)
                    {
                        Command += Compressed[i];
                    }

                    // process command
                    CommandParts = null;
                    CommandParts = Command.Split('x');
                    Next = Convert.ToInt32(CommandParts[0]);
                    Repeat = Convert.ToInt32(CommandParts[1]);

                    Sequence = Compressed.Substring(i + 1, Next);
                    Length += GetDecompressedLength(Sequence) * Repeat;

                    // move i forward
                    i += Next;

                    // reset variables
                    Sequence = "";
                    Command = "";
                }
                else
                {
                    Length++;
                }
            }

            return Length;
        }
    }
}
