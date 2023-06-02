using System;

namespace Day1
{
  class Program
  {
    static void Main(string[] args)
    {
        String? input;
        int[] calories = new int[] { 0, 0, 0 };
        
        int bestOrder = 0;
        bool ok = false;

        // Get the input
        do
        {
            Console.WriteLine("Provide a path for the file:");
            input = Console.ReadLine();
            Console.WriteLine("input = " + input);

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

        using (StreamReader sr = new StreamReader(input)) {
            String? line;
            int adding;
            int currCalories = 0;
            while ((line = sr.ReadLine()) != null) {
                if (Int32.TryParse(line, out adding)) {
                    currCalories += adding;
                    continue;
                } else if (line != "") {
                    throw new Exception("Invalid input! Expected int, received unknown.");
                }

                if (currCalories >= calories[bestOrder]) {
                    //replace the smallest result with the new best
                    calories[(bestOrder + 2) % 3] = currCalories;

                    //and move bestOrder to that
                    bestOrder = (bestOrder + 2) % 3;
                } else if (currCalories > calories[(bestOrder + 1) % 3]) {
                    // in this case, it's better than the second best
                    // but not the best
                    // so first we need to put the current second into third
                    calories[(bestOrder + 2) % 3] = calories[(bestOrder + 1) % 3];

                    // then put currCalories into second
                    calories[(bestOrder + 1) % 3] = currCalories;
                } else if (currCalories > calories[(bestOrder + 2) % 3]) {
                    //replace the smallest result with the new smallest result
                    calories[(bestOrder + 2) % 3] = currCalories;
                }

                // don't forget to set currCalories back to 0 before you start again! dummy.
                currCalories = 0;
            }
        }

        Console.WriteLine("The top three elves are carrying: " 
            + calories[bestOrder] + ", "
            + calories[(bestOrder + 1) % 3] + " and " 
            + calories[(bestOrder + 2) % 3] + " calories.");
        Console.WriteLine("In total, that is: " + (calories[0] + calories[1] + calories[2]) + " calories.");
        Console.WriteLine("Exiting...");
        
        // Iterate through the list, adding up the number of calories
            // If the calories are greater than the current max, set that as max and the biggest elf as this address
            // else, continue to the next elf
        // when you reach the end, output the calories and the number of the elf that carries them (add one for indexing)
    }
  }
}
