namespace MoviesGenreAPI.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public string Image { get; set; }
        public string Synopsis { get; set; }
        public string Duration { get; set; }
        public string Release { get; set; }
        public float Rating { get; set; }
        public User User { get; set; }
    }
}
