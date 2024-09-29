namespace EasyPeasy.Application.DTOs;

public record ModelDto
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public int Year { get; private set; }
    public string Motor { get; private set; }
}