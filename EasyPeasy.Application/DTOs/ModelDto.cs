namespace EasyPeasy.Application.DTOs;

public record ModelDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Motor { get; set; }
}