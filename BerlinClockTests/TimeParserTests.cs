using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;

namespace BerlinClockTests
{
    [TestClass]
    public class TimeParserTests
    {
        [TestMethod]
        public void ShouldParseCorrectTimeString()
        {
            CheckCorrectTime(23, 59, 59);
            CheckCorrectTime(0, 0, 0);
            CheckCorrectTime(24, 0, 0);
            CheckCorrectTime(13, 17, 1);
        }

        private void CheckCorrectTime(int hours, int minutes, int seconds)
        {
            // Arrange
            var parser = new TimeParser();
            // Act
            var parsed = parser.Parse(string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds));
            // Assert
            Assert.AreEqual(hours, parsed.Hours);
            Assert.AreEqual(minutes, parsed.Minutes);
            Assert.AreEqual(seconds, parsed.Seconds);
        }

        [TestMethod]
        public void ShouldReturnDefaultForIncorrectTimeString()
        {
            CheckIncorrectTime("23:59");
            CheckIncorrectTime("aaaaaaa");
            CheckIncorrectTime("23:59:59:33");
            CheckIncorrectTime("43:23:35:56");
        }

        [TestMethod]
        public void ShouldReturnDefaultForCorrectTimeStringWithIncorrectHoursMinutesSeconds()
        {
            CheckIncorrectTime("25:00:00");
            CheckIncorrectTime("21:60:00");
            CheckIncorrectTime("03:00:82");
            CheckIncorrectTime("24:01:02");
        }

        private void CheckIncorrectTime(string aTime)
        {
            // Arrange
            var parser = new TimeParser();
            // Act
            var parsed = parser.Parse(aTime);
            // Assert
            Assert.AreEqual(-1, parsed.Hours);
            Assert.AreEqual(-1, parsed.Minutes);
            Assert.AreEqual(-1, parsed.Seconds);
        }
    }
}
