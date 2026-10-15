using System;

namespace proyecto_aspnet.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Namge { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
}
