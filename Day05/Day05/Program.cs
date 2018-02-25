using System;
using System.Security.Cryptography;
using System.Text;

namespace Day05
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string Input = "ugkcyxxp";

            Console.WriteLine("Part1: " + Part1(Input)); // d4cd2ee1
            Console.WriteLine("Part2: " + Part2(Input)); // f2c730e5
        }


        public static string Part1(string Input)
        {
            string Result = "";
            string Hash = "";

            using (MD5 md5 = MD5.Create())
            {
                for (int i = 0; Result.Length < 8; i++)
                {
                    Hash = GetMd5Hash(md5, Input + i);

                    if (Hash.Substring(0, 5) == "00000")
                    {
                        Result += Hash[5];
                    }
                }
            }

            return Result;
        }


        public static string Part2(string Input)
        {
            char[] Result = new char[8];
            for (int i = 0; i < Result.Length; i++)
            {
                Result[i] = ' ';
            }

            string Hash = "";

            using (MD5 md5 = MD5.Create())
            {
                string Tmp = "       ";
                for (int i = 0; Tmp.Contains(" "); i++)
                {
                    Hash = GetMd5Hash(md5, Input + i);

                    if (Hash.Substring(0, 5) == "00000")
                    {
                        if (Hash[5] == '0'
                            || Hash[5] == '1'
                           || Hash[5] == '2'
                           || Hash[5] == '3'
                           || Hash[5] == '4'
                           || Hash[5] == '5'
                           || Hash[5] == '6'
                           || Hash[5] == '7')
                        {
                            int Value = (int)char.GetNumericValue(Hash[5]);

                            if (Result[Value] == ' ')
                            {
                                Result[Value] = Hash[6];
                            }
                            Console.WriteLine(new string(Result));
                        }
                    }

                    Tmp = new string(Result);
                }
            }

            return new string(Result);
        }


        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
