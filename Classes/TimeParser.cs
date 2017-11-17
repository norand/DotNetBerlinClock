﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class TimeParser : ITimeParser
    {
        static string pattern = @"(\d{2}):(\d{2}):(\d{2})";

        public ParsedTime Parse(string input)
        {
            int hours = -1;
            int minutes = -1;
            int seconds = -1;
            string preparedInput = input.Trim();
            if (preparedInput.Length == 8)
            {
                MatchCollection matches = Regex.Matches(preparedInput, pattern);
                if (matches.Count == 1)
                {
                    hours = Int32.Parse(matches[0].Groups[1].Value);
                    minutes = Int32.Parse(matches[0].Groups[2].Value);
                    seconds = Int32.Parse(matches[0].Groups[3].Value);
                }
            }
            
            return new ParsedTime(hours, minutes, seconds);
        }
    }
}
