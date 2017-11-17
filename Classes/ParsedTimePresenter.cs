using System.Text;

namespace BerlinClock.Classes
{
    public class ParsedTimePresenter : IPresenter
    {
        public const string YELLOW = "Y";
        public const string RED = "R";
        public const string OFF = "O";

        public string GetView(ParsedTime parsedTime)
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetSecondsView(parsedTime.Seconds));
            sb.AppendLine(GetHoursView(parsedTime.Hours));
            sb.Append(GetMinutesView(parsedTime.Minutes));

            return sb.ToString();
        }

        public string GetSecondsView(int seconds)
        {
            var even = seconds % 2;
            if (even == 0) return YELLOW;
            return OFF;
        }

        public string GetHoursView(int hours)
        {
            var hoursFirstRowOn = hours / 5;
            var hoursSecondRowOn = hours % 5;
            var result = new StringBuilder(10);
            var hoursFirstRow = new StringBuilder(4);
            var hoursSecondRow = new StringBuilder(4);
            for (int i = 0; i < 4; i++)
            {
                var itemFirst = i < hoursFirstRowOn ? RED : OFF;
                hoursFirstRow.Append(itemFirst);

                var itemSecond = i < hoursSecondRowOn ? RED : OFF;
                hoursSecondRow.Append(itemSecond);
            }
            result.AppendLine(hoursFirstRow.ToString());
            result.Append(hoursSecondRow.ToString());
            return result.ToString();
        }

        public string GetMinutesView(int minutes)
        {
            var minutesFirstRowOn = minutes / 5;
            var minutesSecondRowOn = minutes % 5;
            var result = new StringBuilder(20);
            var rowFirstRow = new StringBuilder(11);
            var rowSecondRow = new StringBuilder(4);
            for (int i = 0; i < 11; i++)
            {
                var item = i < minutesFirstRowOn ? ((i + 1) % 3 == 0 ? RED : YELLOW) : OFF;
                rowFirstRow.Append(item);
            }
            for (int i = 0; i < 4; i++)
            {
                var item = i < minutesSecondRowOn ? YELLOW : OFF;
                rowSecondRow.Append(item);
            }
            result.AppendLine(rowFirstRow.ToString());
            result.Append(rowSecondRow.ToString());
            return result.ToString();
        }
    }
}
