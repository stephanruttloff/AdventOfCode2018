using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var corrections =
                File
                    .ReadAllLines(@"input.txt")
                    .Select(x =>
                    {
                        switch (x.Substring(0, 1))
                        {
                            case @"+":
                                return int.Parse(x.Substring(1));
                            case @"-":
                                return int.Parse(x.Substring(1)) * -1;
                            default:
                                throw new InvalidOperationException();
                        }
                    })
                    .ToList();

            var frequencies = new HashSet<int> {0};
            var frequency = 0;
            var rounds = 0;

            for (var i = 0; i <= corrections.Count; i++)
            {
                if (i == corrections.Count)
                {
                    i = -1;
                    rounds++;
                    continue;
                }

                frequency += corrections[i];
                if (frequencies.Contains(frequency))
                    break;
                frequencies.Add(frequency);
            }

            Console.WriteLine($"It took {rounds} rounds to find {frequency}");
            Console.ReadKey();
        }
    }
}
