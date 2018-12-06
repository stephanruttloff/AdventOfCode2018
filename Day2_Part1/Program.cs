using System;
using System.IO;
using System.Linq;

namespace Day2_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var counts =
                File
                    .ReadAllLines(@"input.txt")
                    .Select(x =>
                    {
                        var grouped = x.GroupBy(y => y).ToList();

                        return new
                        {
                            Doubles = grouped.Any(y => y.Count() == 2),
                            Triples = grouped.Any(y => y.Count() == 3)
                        };
                    })
                    .ToList();

            var doubleCount = counts.Count(x => x.Doubles);
            var tripleCount = counts.Count(x => x.Triples);
            var result = doubleCount * tripleCount;

            Console.WriteLine($"{doubleCount} * {tripleCount} = {result}");
            Console.ReadKey();
        }
    }
}
