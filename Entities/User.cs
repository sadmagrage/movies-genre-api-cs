namespace MoviesGenreAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public string Role { get; set; }
    }
}
