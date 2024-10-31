using ApplicationCore.Entities;

namespace MovieApp.WebMVC.Models
{
    public class MoviesByGenreModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Genre { get; set; }
    }
}
