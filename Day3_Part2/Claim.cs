using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Day3_Part2
{
    internal class Claim
    {
        #region Constants

        private const string Regex_Entry = @"^#(\d+)\s@\s(\d+),(\d+):\s(\d+)x(\d+)$";

        #endregion

        #region Properties

        public int Id { get; }
        public string Entry { get; }
        public Rectangle Rectangle { get; }

        #endregion

        #region Constructor

        public Claim(string entry)
        {
            var match = Regex.Match(entry, Regex_Entry);

            if(!match.Success)
                throw new ArgumentException($"Invalid input: {entry}");

            Id = int.Parse(match.Groups[1].Value);
            Entry = entry;
            var x = int.Parse(match.Groups[2].Value);
            var y = int.Parse(match.Groups[3].Value);
            var width = int.Parse(match.Groups[4].Value);
            var height = int.Parse(match.Groups[5].Value);
            Rectangle = new Rectangle(x, y, width, height);
        }

        #endregion
    }
}
