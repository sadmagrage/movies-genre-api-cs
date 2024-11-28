using Microsoft.EntityFrameworkCore;
using MoviesGenreAPI.Entities;

namespace MoviesGenreAPI.Context
{
    public class MoviesGenreAPIContext: DbContext
    {
        public MoviesGenreAPIContext(DbContextOptions<MoviesGenreAPIContext> options) : base(options) { }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(e => new { e.GenreId, e.MovieId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.MovieGenres)
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(e => e.Genre)
                .WithMany(e => e.MovieGenres)
                .HasForeignKey(e => e.GenreId);

            modelBuilder.Entity<Movie>()
                .ToTable("movie");

            modelBuilder.Entity<Genre>()
                .ToTable("genre");

            modelBuilder.Entity<MovieGenre>()
                .ToTable("movie-genre");

            modelBuilder.Entity<User>()
                .ToTable("user-db");
        }
    }
}
