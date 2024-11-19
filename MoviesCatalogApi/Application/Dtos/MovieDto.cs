namespace MovieCatalogApi.Application.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int? UserRating { get; set; }
        public string Status { get; set; }
    }
}
