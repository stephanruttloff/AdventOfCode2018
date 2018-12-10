using System;
using System.IO;

namespace Day5_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var units = File.ReadAllText(@"input.txt");

            Console.WriteLine($"Loaded {units.Length} units");

            for (var i = 0; i < units.Length - 1; i++)
            {
                var a = units[i];
                var b = units[i + 1];

                if(a == b)
                    continue;

                if (char.ToLowerInvariant(a) != char.ToLowerInvariant(b))
                    continue;

                units = units.Remove(i, 2);

                i -= 2;

                if (i % 2 != 0 || i < 0) // start from beginning
                    i = -1;
            }

            Console.WriteLine($"Reduced to {units.Length} units");
            Console.ReadKey();
        }
    }
}
