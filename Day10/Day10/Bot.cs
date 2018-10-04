using System;
using System.Collections.Generic;

namespace Day10
{
    public class Bot
    {
        public Bot(Dictionary<int, Bot> bots, Dictionary<int, int> output, int id)
        {
            this.Bots = bots;
            this.Output = output;
            this.Id = id;
        }

        public void GiveMicrochip(int microchip)
        {
            if (this.Microchips[0] == -1)
            {
                this.Microchips[0] = microchip;
            }
            else if (this.Microchips[1] == -1)
            {
                this.Microchips[1] = microchip;
            }
            else
            {
                throw new Exception("Bot can only carry 2 microchips");
            }

            if (this.Microchips[0] != -1 && this.Microchips[1] != -1)
            {
                this.Execute();
            }
        }

        public void GiveInstruction(bool lowBot, int lowId, bool highBot, int highId)
        {
            this.LowBot = lowBot;
            this.LowId = lowId;
            this.HighBot = highBot;
            this.HighId = highId;

            this.Instruction = true;

            if (this.Microchips[0] != -1 && this.Microchips[1] != -1)
            {
                this.Execute();
            }
        }

        private void Execute()
        {
            if (this.Instruction)
            {
                if ((this.Microchips[0] == 61 && this.Microchips[1] == 17) || (this.Microchips[0] == 17 && this.Microchips[1] == 61))
                {
                    Console.WriteLine("Part1: " + this.Id);
                    // 161
                }

                if (this.Microchips[0] > this.Microchips[1])
                {
                    if (this.LowBot)
                    {
                        // give low to bot
                        if (!this.Bots.ContainsKey(LowId))
                        {
                            this.Bots.Add(LowId, new Bot(Bots, Output, LowId));
                        }

                        this.Bots[LowId].GiveMicrochip(this.Microchips[1]);
                    }
                    else
                    {
                        // give low to output
                        if (this.Output.ContainsKey(LowId))
                        {
                            this.Output[LowId] = this.Microchips[1];
                        }
                        else
                        {
                            this.Output.Add(LowId, this.Microchips[1]);
                        }
                    }

                    if (this.HighBot)
                    {
                        // give high to bot
                        if (!this.Bots.ContainsKey(HighId))
                        {
                            this.Bots.Add(HighId, new Bot(Bots, Output, HighId));
                        }

                        this.Bots[HighId].GiveMicrochip(this.Microchips[0]);
                    }
                    else
                    {
                        // give high to output
                        if (this.Output.ContainsKey(HighId))
                        {
                            this.Output[HighId] = this.Microchips[0];
                        }
                        else
                        {
                            this.Output.Add(HighId, this.Microchips[0]);
                        }
                    }
                }
                else if (this.Microchips[0] < this.Microchips[1])
                {
                    if (this.LowBot)
                    {
                        // give low to bot
                        if (!this.Bots.ContainsKey(LowId))
                        {
                            this.Bots.Add(LowId, new Bot(Bots, Output, LowId));
                        }

                        this.Bots[LowId].GiveMicrochip(this.Microchips[0]);
                    }
                    else
                    {
                        // give low to output
                        if (this.Output.ContainsKey(LowId))
                        {
                            this.Output[LowId] = this.Microchips[0];
                        }
                        else
                        {
                            this.Output.Add(LowId, this.Microchips[0]);
                        }
                    }

                    if (this.HighBot)
                    {
                        // give high to bot
                        if (!this.Bots.ContainsKey(HighId))
                        {
                            this.Bots.Add(HighId, new Bot(Bots, Output, HighId));
                        }

                        this.Bots[HighId].GiveMicrochip(this.Microchips[1]);
                    }
                    else
                    {
                        // give high to output
                        if (this.Output.ContainsKey(HighId))
                        {
                            this.Output[HighId] = this.Microchips[1];
                        }
                        else
                        {
                            this.Output.Add(HighId, this.Microchips[1]);
                        }
                    }
                }
                else
                {
                    throw new Exception("Unexpected behavior: Bot executing but has equal value microchips");
                }

                // reset values
                this.Microchips = new int[] { -1, -1 };
            }
        }

        public int Id { get; set; }

        private Dictionary<int, int> Output;

        private Dictionary<int, Bot> Bots;

        private int[] Microchips = new int[] { -1, -1 };

        private bool Instruction;

        private bool LowBot;

        private bool HighBot;

        private int LowId;

        private int HighId;

        public override string ToString()
        {
            return String.Format("Bot {0}: microchips: ({1};{2})", this.Id, this.Microchips[0], this.Microchips[1]);
        }
    }
}
