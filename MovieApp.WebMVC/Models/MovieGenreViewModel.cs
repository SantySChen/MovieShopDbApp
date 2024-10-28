using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieApp.WebMVC.Models
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public string? MovieGenre {  get; set; }
        public string? SearchString { get; set; }
    }
}
