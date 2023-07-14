using System;
using Utils;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            String input =
            Utils.Input.getInput();

            string? line;
            int count = 0;
            using (StreamReader sr = new StreamReader(input))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] inputs = line.Split(',');
                    int[] small = new int[2];
                    int[] large = new int[2];

                    for (int i = 0; i < inputs.Length; i++)
                    {
                        string[] sectors = inputs[i].Split('-');
                        small[i] = int.Parse(sectors[0]);
                        large[i] = int.Parse(sectors[1]);
                    }

                    if ((small[0] <= small[1] && large[0] >= large[1]) ||
                    (small[0] >= small[1] && large[0] <= large[1]))
                    {
                        count++;
                        //Console.WriteLine(small[0] + " and " + large[0] + " either encapsulate or are encapsulated by " + small[1] + " and " + large[1]);
                    }
                }
                Console.WriteLine("Part 1 final total: " + count);
            }

            // PART 2 - How many intersections everywhere?
            count = 0;
            using (StreamReader sr = new StreamReader(input))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] inputs = line.Split(',');
                    int[] small = new int[2];
                    int[] large = new int[2];
                    for (int i = 0; i < inputs.Length; i++)
                    {
                        string[] sectors = inputs[i].Split('-');
                        small[i] = int.Parse(sectors[0]);
                        large[i] = int.Parse(sectors[1]);
                    }
                    HashSet<int> set = new HashSet<int>();
                    if (inHash(small[0], large[0], set) || inHash(small[1], large[1], set))
                    {
                        count++;
                    }
                }
                Console.WriteLine("Part 2 final total: " + count);
            }
        }

        static bool inHash(int min, int max, HashSet<int> hash)
        {
            for (int j = min; j <= max; j++)
            {
                bool hashBool = hash.Add(j);
                if (hashBool == false)
                {
                    // already exists in unique array so it must have an overlap somewhere
                    return true;
                }
            }
            return false;
        }
    }
}