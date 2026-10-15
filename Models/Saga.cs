using System;

namespace proyecto_aspnet.Models;

public class Saga
{
public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
}
