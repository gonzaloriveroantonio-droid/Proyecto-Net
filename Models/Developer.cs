using System;

namespace proyecto_aspnet.Models;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
    public List<GameEngine> GameEngines { get; set; } = new();
}
