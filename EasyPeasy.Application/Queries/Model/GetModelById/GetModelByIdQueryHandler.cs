using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Queries.Model.GetModelById;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetModelById;

public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, ModelDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetModelByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ModelDto> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var model = await _unitOfWork.Models.GetByIdAsync(request.Id);
        
        return _mapper.Map<ModelDto>(model);
    }
}