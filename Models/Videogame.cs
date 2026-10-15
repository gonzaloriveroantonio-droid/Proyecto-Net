using System;

namespace proyecto_aspnet.Models;

public class Videogame
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public decimal ReleasePrice { get; set; }
    public string? Description { get; set; }
    public int Players { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = new();
    public int DeveloperId { get; set; }
    public Developer Developer { get; set; } = new();
    public List<Genre> Genres { get; set; } = new();
    public List<SubGenre> SubGenres { get; set; } = new();
    public List<Language> Languages { get; set; } = new();
    public GameEngine GameEngine { get; set; }
    public List<VideoConsole> VideoConsoles { get; set; } = new();
    public int SagaId { get; set; }
    public Saga? Saga { get; set; }

    /*

Producción: Kojima Productions

Formato: 1 UMD
Textos: Español
Voces: Inglés*/
}
