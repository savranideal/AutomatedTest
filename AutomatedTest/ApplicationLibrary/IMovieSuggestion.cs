namespace ApplicationLibrary
{
    public interface IMovieSuggestion
    {
        bool IsGoodMovie(string title);

        bool IsBadMovie(string title);
    }
}
