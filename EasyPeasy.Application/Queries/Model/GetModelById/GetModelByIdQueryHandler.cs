using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Queries.Model.GetModelById;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetModelById;

public class GetModelByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetModelByIdQuery, ResultDto<ModelDto>>
{
    public async Task<ResultDto<ModelDto>> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);
        
        if (model == null)
        {
            return ResultDto<ModelDto>.Failure($"Model '{request.Id}' not exist.");
        }

        var modelDto = mapper.Map<ModelDto>(model);
        
        return ResultDto<ModelDto>.Success(modelDto);
    }
}