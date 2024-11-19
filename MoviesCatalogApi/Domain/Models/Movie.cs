using MovieCatalogApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalogApi.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Year { get; set; }
        public required string Director { get; set; }
        public required string Genre { get; set; }
        public int? UserRating { get; set; }
        public MovieStatus Status { get; set; }
    }
   

}
