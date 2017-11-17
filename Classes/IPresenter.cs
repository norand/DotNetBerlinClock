namespace BerlinClock.Classes
{
    public interface IPresenter
    {
        string GetView(ParsedTime parsedTime);
    }
}