using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetModelById;

public class GetModelByIdQuery : IRequest<ModelDto>
{
    public GetModelByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; set; }
}