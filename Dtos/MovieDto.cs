namespace MoviesGenreAPI.Dtos
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> Genres { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }
        public string Synopsis { get; set; }
        public float Rating { get; set; }
        public string Release { get; set; }
    }
}
