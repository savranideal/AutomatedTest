using System;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class MovieSuggestion : IMovieSuggestion
    {
        private readonly IMovieScore movieScore;

        public MovieSuggestion(IMovieScore movieScore)
        {
            this.movieScore = movieScore;
        }
         
        public async Task<bool> IsGoodMovieAsync(Guid movieId)
        {
            var score = await movieScore.ScoreAsync(movieId);
            return score >= 8;
        }

    }
}
