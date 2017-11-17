namespace BerlinClock.Classes
{
    public interface ITimeParser
    {
        ParsedTime Parse(string input);
    }
}