using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLibrary.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; } 
        public int ReleasedYear { get; set; }  
        public decimal ImdbRating { get; set; } 
  
    }
}
