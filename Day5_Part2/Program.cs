using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var units = File.ReadAllText(@"input.txt");

            Console.WriteLine($"Loaded {units.Length} units");

            var individualUnits =
                units
                    .Select((c, i) => new {Unit = c, Index = i})
                    .GroupBy(x => char.ToLowerInvariant(x.Unit))
                    .OrderBy(x => x.Key)
                    .ToList();
            var results = new Dictionary<char, int>();

            foreach (var individualUnit in individualUnits)
            {
                var tmp =
                    individualUnit
                        .OrderByDescending(x => x.Index)
                        .Aggregate(units, (current, occurence) => current.Remove(occurence.Index, 1));

                Console.WriteLine($"Trying without unit {individualUnit.Key} ({tmp.Length} units remaining)");

                for (var i = 0; i < tmp.Length - 1; i++)
                {
                    var a = tmp[i];
                    var b = tmp[i + 1];

                    if (a == b)
                        continue;

                    if (char.ToLowerInvariant(a) != char.ToLowerInvariant(b))
                        continue;

                    tmp = tmp.Remove(i, 2);

                    i -= 2;

                    if (i % 2 != 0 || i < 0) // start from beginning
                        i = -1;
                }

                Console.WriteLine($"Reduced to {tmp.Length} units");
                results.Add(individualUnit.Key, tmp.Length);
            }

            var faultyUnit = results.OrderBy(x => x.Value).First();

            Console.WriteLine($"Removing faulty unit {faultyUnit.Key} results in {faultyUnit.Value} remaining units");
            Console.ReadKey();
        }
    }
}
