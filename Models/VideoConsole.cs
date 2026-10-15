using System;

namespace proyecto_aspnet.Models;

public class VideoConsole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
    //public IFormFile? ImageFile { get; set; }
    public decimal ReleasePrice { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
}
