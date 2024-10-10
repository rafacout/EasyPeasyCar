using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetModelById;

public class GetModelByIdQuery(Guid id) : IRequest<ResultDto<ModelDto>>
{
    public Guid Id { get; set; } = id;
}