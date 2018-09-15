using System;
using System.IO;

namespace Day09
{
    class MainClass
    {
        public static void Main(string[] args)
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

            Console.WriteLine("The decompressed length is: {0}", Decompressed.Length);
            // 74532
        }
    }
}
