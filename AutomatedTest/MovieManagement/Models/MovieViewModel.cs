using System;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Director { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        [Required(ErrorMessage = "ReleasedYear is required")]
        public int ReleasedYear { get; set; }

         
        [Required(ErrorMessage = "ImdbRating is required")]
        public decimal ImdbRating { get; set; }

    }
}
