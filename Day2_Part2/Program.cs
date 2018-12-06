using System;
using System.IO;
using System.Linq;

namespace Day2_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ids = File.ReadAllLines(@"input.txt");

            string first = string.Empty, second = string.Empty, common = string.Empty;

            for (var i = 0; i < ids.Length - 1; i++)
            {
                first = ids[i];

                for (var j = i + 1; j < ids.Length; j++)
                {
                    second = ids[j];

                    var compared = first.Zip(second, (f, s) => Equals(f, s)).ToArray();

                    if (compared.Count(x => !x) != 1)
                        continue;

                    common = string.Concat(first.Select((c, k) => compared[k] ? c : ' '));
                    break;
                }

                if (!string.IsNullOrEmpty(common))
                    break;
            }

            Console.WriteLine($"First:  {first}");
            Console.WriteLine($"Second: {second}");
            Console.WriteLine($"Common: {common}");
            Console.ReadKey();
        }
    }
}
