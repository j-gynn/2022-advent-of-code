using System;

namespace Utils 
{
    public class Input 
    {
        public static void Main(string[] args)
        { 

        }
        public static string getInput() {
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
            return input;
        }
    }
}