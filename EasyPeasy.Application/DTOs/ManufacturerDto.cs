﻿namespace EasyPeasy.Application.DTOs;

public record ManufacturerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}