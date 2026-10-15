using System;

namespace proyecto_aspnet.Models;

public class GameEngine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
    public List<VideoConsole> VideoConsoles { get; set; } = new();
    public List<Developer> Developers { get; set; } = new();
}
