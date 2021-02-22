namespace ApplicationLibrary
{
    public class MovieSuggestion : IMovieSuggestion
    {
        private readonly IMovieScore movieScore;

        public MovieSuggestion(IMovieScore movieScore)
        {
            this.movieScore = movieScore;
        }

        public bool IsBadMovie(string title)
        {
            if (string.IsNullOrEmpty(title))
                return false;
            var score = movieScore.Score(title);
            return score <= 4;
        }

        public bool IsGoodMovie(string title)
        {
            if (string.IsNullOrEmpty(title))
                return false;
            var score = movieScore.Score(title);
            return score >= 8;
        }

    }
}
