using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Director { get; set; }

        [Range(1900, 2021, ErrorMessage = "ReleasedYear can only be between 1900 ... 2021")]
        [Required(ErrorMessage = "ReleasedYear is required")]
        public int? ReleasedYear { get; set; }

         
        [Required(ErrorMessage = "ImdbRating is required")]
        [Range(0, 10, ErrorMessage = "ImdbRating can only be between 0 ... 10")]
        public decimal? ImdbRating { get; set; }

    }
}
