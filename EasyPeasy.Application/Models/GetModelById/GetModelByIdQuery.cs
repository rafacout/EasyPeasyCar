using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Models.DTOs;
using MediatR;

namespace EasyPeasy.Application.Models.GetModelById;

public class GetModelByIdQuery(Guid id) : IRequest<ResultDto<ModelDto>>
{
    public Guid Id { get; set; } = id;
}