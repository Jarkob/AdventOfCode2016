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
            // Test
            //Input = "abc";

            string Result = "";
            string Hash = "";

            using (MD5 md5 = MD5.Create())
            {
                for (int i = 0; Result.Length < 8; i++)
                {
                    Hash = GetMd5Hash(md5, Input + i);

                    if(Hash.Substring(0, 5) == "00000")
                    {
                        Result += Hash[5];
                    }
                }
            }

            Console.WriteLine("Part1: " + Result); // d4cd2ee1
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
