using System;
using System.Linq;

using Utils;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = 
            Utils.Input.getInput();
            

            // PART 1 - Find the duplicate in each rucksack
            int count = 0;
            using (StreamReader sr = new StreamReader(input))
            {
                string? total;
                while ((total = sr.ReadLine()) != null) {
                    // split a bag in half
                    char[] bag1 = total.Substring(0, (total.Length/2)).ToCharArray();
                    char[] bag2 = total.Substring(total.Length/2).ToCharArray();

                    // find the duplicate
                    IEnumerable<char> diffQuery = 
                        bag1.Intersect(bag2);

                    // calculate the total
                    // add it to the count
                    count += Utils.Convert.getCharAsNum(diffQuery.First());
                }
                // print the final answer
                Console.WriteLine("Part 1 final total: " + count);
            }

            count = 0;
            // PART 2 - find the identifying item in the 3 squad members
            using (StreamReader sr = new StreamReader(input)) 
            {
                string? rucksack;
                string[] squad = new string[3];
                int elf = 1;
                while ((rucksack = sr.ReadLine()) != null) {
                    if (elf % 3 != 0) {

                        // append rucksack to squad
                        squad[elf % 3] = rucksack;
                        elf++;              
                        continue;
                    }
                    // we have the squad all together
                    squad[0] = rucksack;

                    char intersection = '?';

                    HashSet<char> hashSet = new HashSet<char>(squad[0]);
                    hashSet.IntersectWith(squad[1]);
                    hashSet.IntersectWith(squad[2]);
                    intersection = hashSet.First();
                    elf++;

                    count += Utils.Convert.getCharAsNum(intersection);
                }
                // print the final answer
                Console.WriteLine("Part 2 final total: " + count);
            }
        }
    }
}