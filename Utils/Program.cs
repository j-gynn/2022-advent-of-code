using System;

namespace Utils 
{
    public class Input 
    {
        public static string getInput()
        {
            string? input;
            bool ok = false;
            do
            {
                Console.WriteLine("Provide a path for the file:");
                input = Console.ReadLine();

                if (input == null) {
                    Console.WriteLine("No input received!");
                    continue;
                }

                if (!File.Exists(input)) {
                    Console.WriteLine("File does not exist.");
                    continue;
                }

                // if we get here, the directory exists so we should be good to go.
                ok = true;
            } while (!ok);
            
            if (!string.IsNullOrEmpty(input)) {
                return input;
            } else {
                throw new Exception("Other critical error! No input detected.");
            }
        }
    }

    public class Convert
    {

        /// <summary>
        /// Returns 1-26 for a-z, 27-52 for A-Z. Leaves all other ASCII unchanged.
        ///</summary>
        public static int getCharAsNum(char c) {
            int ascii = (int)c;
            return (ascii >= 97) ? ascii - 96 : (ascii <= 90 && ascii >= 65) ? ascii - 38 : ascii;
        }
    }
}