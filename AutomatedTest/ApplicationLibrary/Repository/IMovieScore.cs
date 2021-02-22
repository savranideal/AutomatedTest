using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public interface IMovieScore
    {
        Task<decimal> ScoreAsync(Guid guid);
    }
}
