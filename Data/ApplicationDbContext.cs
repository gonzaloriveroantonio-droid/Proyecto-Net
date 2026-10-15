using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using proyecto_aspnet.Models;

namespace proyecto_aspnet.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Videogame> Videogames => Set<Videogame>();
    public DbSet<VideoConsole> VideoConsoles => Set<VideoConsole>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<SubGenre> SubGenres => Set<SubGenre>();
    public DbSet<Saga> Sagas => Set<Saga>();
    public DbSet<GameEngine> GameEngines => Set<GameEngine>();

    // TABLAS

}
