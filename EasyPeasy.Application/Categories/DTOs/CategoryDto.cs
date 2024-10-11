namespace EasyPeasy.Application.Categories.DTOs;

public record CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}