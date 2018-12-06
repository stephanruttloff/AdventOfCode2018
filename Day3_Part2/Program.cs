using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var claims = File.ReadAllLines(@"input.txt").Select(x => new Claim(x)).ToList();
            var intersecting = new List<Claim>();

            for (var i = 0; i < claims.Count - 1; i++)
            for (var j = i + 1; j < claims.Count; j++)
            {
                if (claims[i].Rectangle.IntersectsWith(claims[j].Rectangle))
                {
                    intersecting.Add(claims[i]);
                    intersecting.Add(claims[j]);
                }
            }

            var remaining = claims.Except(intersecting).Single();

            Console.WriteLine($"The one good claim: #{remaining.Id}");
            Console.ReadKey();
        }
    }
}
