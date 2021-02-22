using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.Domain
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData
                (
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "The Shawshank Redemption",
                     ReleasedYear = 1994,
                     Director = "Frank Darabont", 
                     ImdbRating = 9.3m, 
                 },
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "Pulp Fiction",
                     ReleasedYear = 1994,
                     Director = "Quentin Tarantino",
                     ImdbRating = 8.9m, 
                 },
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "Léon",
                     ReleasedYear = 1994,
                     Director = "Luc Besson",
                     ImdbRating = 8.5m, 
                 },
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "The Godfather",
                     ReleasedYear = 1972,
                     Director = "Francis Ford Coppola",
                     ImdbRating = 9.2m, 
                 },
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "Schindler's List",
                     ReleasedYear = 1993,
                     Director = "Steven Spielberg",
                     ImdbRating = 8.9m, 
                 },
                 new Movie
                 {
                     Id = Guid.NewGuid(),
                     Name = "The Dark Knight",
                     ReleasedYear = 2008,
                     Director = "Christopher Nolan",
                     ImdbRating = 9.0m, 
                 }
                );
        }




        public DbSet<Movie> Movies { get; set; }
    }
}
