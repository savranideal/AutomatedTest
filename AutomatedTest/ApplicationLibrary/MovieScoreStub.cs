namespace ApplicationLibrary
{
    public class MovieScoreStub : IMovieScore
    {
        private double score;

        public MovieScoreStub(double score)
        {
            this.score = score;
        }

        public double Score(string title)
        {
            return score;
        }
    }
}
