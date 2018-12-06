using System;
using System.IO;
using System.Linq;

namespace Day3_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var claims = File.ReadAllLines(@"input.txt").Select(x => new Claim(x)).ToList();
            var fabricWidth = claims.Max(x => x.RightEdge);
            var fabricHeight = claims.Max(x => x.BottomEdge);
            var fabric = new uint[fabricWidth, fabricHeight];
            var overlapAmount = 0;

            foreach (var claim in claims)
            {
                for(var x = claim.X; x < claim.RightEdge; x++)
                for (var y = claim.Y; y < claim.BottomEdge; y++)
                {
                    fabric[x, y]++;
                    if (fabric[x, y] == 2)
                        overlapAmount++;
                }
            }
            
            Console.WriteLine($"Overlapping: {overlapAmount}");
            Console.ReadKey();
        }
    }
}
