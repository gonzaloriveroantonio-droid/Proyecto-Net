using System;

namespace proyecto_aspnet.Models;

public class VideoConsole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleseDate { get; set; }
    public string? Description { get; set; }
    //public IFormFile? ImageFile { get; set; }
    public decimal PriceReleaseDate { get; set; }
    public List<Videogame> Videogames { get; set; } = new();
}
