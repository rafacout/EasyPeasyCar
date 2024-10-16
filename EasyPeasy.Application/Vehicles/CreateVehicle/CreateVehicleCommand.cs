﻿using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Vehicles.CreateVehicle;

public class CreateVehicleCommand : IRequest<ResultViewModel<Guid>>
{
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public Guid ModelId { get; set; }
    public float DailyRate { get; set; }
    public int Mileage { get; set; }
    public string LicensePlate { get; set; }
    public string Color { get; set; }
    public string StatusVehicle { get; set; }
}