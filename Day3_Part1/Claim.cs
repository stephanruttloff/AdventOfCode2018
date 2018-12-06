using System;
using System.Text.RegularExpressions;

namespace Day3_Part1
{
    internal class Claim
    {
        #region Constants

        private const string Regex_Entry = @"^#(\d+)\s@\s(\d+),(\d+):\s(\d+)x(\d+)$";

        #endregion

        #region Properties

        public int Id { get; }
        public string Entry { get; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public int RightEdge => X + Width;
        public int BottomEdge => Y + Height;

        #endregion

        #region Constructor

        public Claim(string entry)
        {
            var match = Regex.Match(entry, Regex_Entry);

            if(!match.Success)
                throw new ArgumentException($"Invalid input: {entry}");

            Id = int.Parse(match.Groups[1].Value);
            Entry = entry;
            X = int.Parse(match.Groups[2].Value);
            Y = int.Parse(match.Groups[3].Value);
            Width = int.Parse(match.Groups[4].Value);
            Height = int.Parse(match.Groups[5].Value);
        }

        #endregion
    }
}
