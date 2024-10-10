using System.ComponentModel;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Manufacturer.GetAllManufacturers;

public class GetAllManufacturersQuery : IRequest<ResultDto<List<ManufacturerDto>>>
{
}
