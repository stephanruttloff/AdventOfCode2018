using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4_Part1
{
    class Program
    {
        #region Constants

        private const string DateTime_Format = @"yyyy-MM-dd HH:mm";
        private const string Regex_Common_Message = @"^\[(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2})\]\s(.*)$";
        private const string Regex_Message_Start = @"^Guard\s#(\d+)\sbegins\sshift$";
        private const string Regex_Message_Sleep = @"^falls\sasleep$";
        private const string Regex_Message_Wake = @"^wakes\sup$";

        #endregion

        #region Methods

        static void Main(string[] args)
        {
            var messages =
                File
                    .ReadAllLines(@"input.txt")
                    .Select(x =>
                    {
                        var match = Regex.Match(x, Regex_Common_Message);

                        if (!match.Success)
                            throw new FormatException();

                        return new
                        {
                            Timestamp = DateTime.ParseExact(match.Groups[1].Value, DateTime_Format, null),
                            Message = match.Groups[2].Value
                        };
                    })
                    .OrderBy(x => x.Timestamp)
                    .ToList();

            var currentGuard = -1;
            var lastSleepStart = DateTime.MinValue;
            var sleep = new Dictionary<int, int[]>();

            foreach (var message in messages)
            {
                if (Regex.IsMatch(message.Message, Regex_Message_Start))
                {
                    currentGuard = int.Parse(Regex.Match(message.Message, Regex_Message_Start).Groups[1].Value);
                    if (!sleep.ContainsKey(currentGuard))
                        sleep.Add(currentGuard, new int[60]);
                }
                else if (Regex.IsMatch(message.Message, Regex_Message_Sleep))
                {
                    if(currentGuard < 0 || lastSleepStart != DateTime.MinValue)
                        throw new InvalidOperationException();

                    lastSleepStart = message.Timestamp;
                }
                else if (Regex.IsMatch(message.Message, Regex_Message_Wake))
                {
                    if (currentGuard < 0 || lastSleepStart == DateTime.MinValue)
                        throw new InvalidOperationException();

                    for (var i = lastSleepStart.Minute; i < message.Timestamp.Minute; i++)
                        sleep[currentGuard][i]++;

                    lastSleepStart = DateTime.MinValue;
                }
                else
                    throw new FormatException();
            }

            var sleepyGuards = sleep.Select(x => new {Guard = x.Key, SleepCycle = x.Value, SleepCount = x.Value.Sum()})
                .OrderByDescending(x => x.SleepCount);
            var sleepyGuard = sleepyGuards.First();
            var sleepyGuardMinute = sleepyGuard.SleepCycle.ToList().IndexOf(sleepyGuard.SleepCycle.Max());

            Console.WriteLine($"Guard #{sleepyGuard.Guard} slept {sleepyGuard.SleepCount}m in total. Most asleep at 00:{sleepyGuardMinute}.");
            Console.WriteLine($"{sleepyGuard.Guard} * {sleepyGuardMinute} = {sleepyGuard.Guard * sleepyGuardMinute}");
            Console.ReadKey();
        }

        #endregion
    }
}
