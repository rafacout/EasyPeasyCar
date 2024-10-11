using AutoMapper;
using EasyPeasy.Application.Categories.DTOs;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using EasyPeasy.Application.Models.DTOs;
using EasyPeasy.Application.Rents.DTOs;
using EasyPeasy.Application.Stores.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Application.Vehicles.DTOs;
using EasyPeasy.Domain.Entities;

namespace EasyPeasy.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Manufacturer, ManufacturerDto>();
        CreateMap<Model, ModelDto>();
        CreateMap<Rent, RentDto>();
        CreateMap<Store, StoreDto>();
        CreateMap<User, UserDto>();
        CreateMap<Vehicle, VehicleDto>();
    }
}