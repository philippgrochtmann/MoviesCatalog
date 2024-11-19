using Microsoft.Extensions.Caching.Memory;
using MovieCatalogApi.Infrastructure.Services.Models;
using Newtonsoft.Json;

namespace MovieCatalogApi.Infrastructure.Services
{
    public class OMDBService : IOMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _apiKey;

        public OMDBService(HttpClient httpClient, IMemoryCache cache, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _cache = cache;
            _apiKey = configuration["OMDB:ApiKey"];
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(string title)
        {
            if (_cache.TryGetValue(title, out MovieDetails cachedMovie))
            {
                return cachedMovie;
            }

            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?t={title}&apikey={_apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(content);

            if (movieDetails.Response == "False")
            {
                return null;
            }

            _cache.Set(title, movieDetails, TimeSpan.FromHours(1));

            return movieDetails;
        }
    }
}
