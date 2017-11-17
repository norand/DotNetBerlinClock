using System.Text;

namespace BerlinClock.Classes
{
    public class ParsedTime
    {
        public readonly int Hours;
        public readonly int Minutes;
        public readonly int Seconds;

        public ParsedTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }

}