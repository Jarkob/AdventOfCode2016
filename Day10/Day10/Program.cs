using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");

            // test
            //Input = new string[] {
            //    "value 5 goes to bot 2",
            //    "bot 2 gives low to bot 1 and high to bot 0",
            //    "value 3 goes to bot 1",
            //    "bot 1 gives low to output 1 and high to bot 0",
            //    "ot 0 gives low to output 2 and high to output 0",
            //    "value 2 goes to bot 2"
            //};

            Dictionary<int, Bot> Bots = new Dictionary<int, Bot>();
            Dictionary<int, int> Output = new Dictionary<int, int>();

            string[] Instruction;
            foreach (var element in Input)
            {
                Instruction = element.Split(' ');
                if (Instruction[2] == "goes")
                {
                    // give value to bot
                    int BotId = Convert.ToInt32(Instruction[5]);
                    int Value = Convert.ToInt32(Instruction[1]);

                    if (Bots.ContainsKey(BotId))
                    {
                        Bots[BotId].GiveMicrochip(Value);
                    }
                    else
                    {
                        Bots.Add(BotId, new Bot(Bots, Output, BotId));
                        Bots[BotId].GiveMicrochip(Value);
                    }
                }
                else if (Instruction[2] == "gives")
                {
                    // give bot instruction
                    int BotId = Convert.ToInt32(Instruction[1]);
                    bool LowBot = (Instruction[5] == "bot");
                    int LowId = Convert.ToInt32(Instruction[6]);
                    bool HighBot = (Instruction[10] == "bot");
                    int HighId = Convert.ToInt32(Instruction[11]);

                    if (!Bots.ContainsKey(BotId))
                    {
                        Bots.Add(BotId, new Bot(Bots, Output, BotId));
                    }

                    Bots[BotId].GiveInstruction(LowBot, LowId, HighBot, HighId);
                }
                else
                {
                    throw new Exception("Instructions unclear: " + element);
                }
            }

            int Result = Output[0] * Output[1] * Output[2];
            Console.WriteLine("Part2: " + Result);
            // 133163
        }
    }
}
