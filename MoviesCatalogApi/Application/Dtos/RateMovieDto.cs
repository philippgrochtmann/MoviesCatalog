using System.ComponentModel;

namespace MovieCatalogApi.Application.Dtos
{
    public class RateMovieDto
    {
        [DefaultValue(5)]
        public int Rating { get; set; } 
    }
}
