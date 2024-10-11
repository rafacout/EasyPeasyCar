using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Manufacturers.DTOs;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.GetAllManufacturers;

public class GetAllManufacturersQuery : IRequest<ResultViewModel<List<ManufacturerViewModel>>>
{
}
