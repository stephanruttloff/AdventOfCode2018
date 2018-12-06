using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var frequencyCorrection =
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
                    .Sum();

            Console.WriteLine(frequencyCorrection);
            Console.ReadKey();
        }
    }
}
