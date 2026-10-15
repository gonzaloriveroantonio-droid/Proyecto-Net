using System;

namespace proyecto_aspnet.Models;

public class SubGenre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
    
}
