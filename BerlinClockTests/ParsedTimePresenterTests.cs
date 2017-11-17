using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;
using System.Text;

namespace BerlinClockTests
{
    [TestClass]
    public class ParsedTimePresenterTests
    {
        [TestMethod]
        public void GetSecondsView_ShouldReturnOffForNotEvenSeconds()
        {
            CheckExpectedSeconds(59, ParsedTimePresenter.OFF);
            CheckExpectedSeconds(1, ParsedTimePresenter.OFF);
            CheckExpectedSeconds(13, ParsedTimePresenter.OFF);
        }

        [TestMethod]
        public void GetSecondsView_ShouldReturnYellowForEvenSeconds()
        {
            CheckExpectedSeconds(0, ParsedTimePresenter.YELLOW);
            CheckExpectedSeconds(12, ParsedTimePresenter.YELLOW);
            CheckExpectedSeconds(48, ParsedTimePresenter.YELLOW);
        }

        [TestMethod]
        public void GetHoursView_ShouldReturnCorrectView()
        {
            CheckExpectedHours(23, CombineRows("RRRR", "RRRO"));
            CheckExpectedHours(0, CombineRows("OOOO", "OOOO"));
            CheckExpectedHours(7, CombineRows("ROOO", "RROO"));
        }

        [TestMethod]
        public void GetMinutesView_ShouldReturnCorrectView()
        {
            CheckExpectedMinutes(0, CombineRows("OOOOOOOOOOO", "OOOO"));
            CheckExpectedMinutes(3, CombineRows("OOOOOOOOOOO", "YYYO"));
            CheckExpectedMinutes(4, CombineRows("OOOOOOOOOOO", "YYYY"));
            CheckExpectedMinutes(5, CombineRows("YOOOOOOOOOO", "OOOO"));
            CheckExpectedMinutes(10, CombineRows("YYOOOOOOOOO", "OOOO"));
            CheckExpectedMinutes(15, CombineRows("YYROOOOOOOO", "OOOO"));
            CheckExpectedMinutes(59, CombineRows("YYRYYRYYRYY", "YYYY"));
        }

        private void CheckExpectedSeconds(int seconds, string expected)
        {
            // Arrange
            var presenter = new ParsedTimePresenter();
            // Act
            var result = presenter.GetSecondsView(seconds);
            // Assert
            Assert.AreEqual(expected, result);
        }

        private string CombineRows(string row1, string row2)
        {
            var sb = new StringBuilder(10);
            sb.AppendLine(row1);
            sb.Append(row2);
            return sb.ToString();
        }

        private void CheckExpectedHours(int hours, string expected)
        {
            // Arrange
            var presenter = new ParsedTimePresenter();
            // Act
            var result = presenter.GetHoursView(hours);
            // Assert
            Assert.AreEqual(expected, result);
        }

        private void CheckExpectedMinutes(int minutes, string expected)
        {
            // Arrange
            var presenter = new ParsedTimePresenter();
            // Act
            var result = presenter.GetMinutesView(minutes);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
