using AutoMapper;
using EasyPeasy.Application.DTOs;
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