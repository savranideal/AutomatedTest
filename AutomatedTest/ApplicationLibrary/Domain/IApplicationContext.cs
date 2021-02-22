using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApplicationLibrary.Domain
{
    public interface IApplicationContext
    {
        DbSet<Movie> Movies { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
