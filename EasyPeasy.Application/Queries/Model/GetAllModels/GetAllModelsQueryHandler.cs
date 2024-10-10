using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetAllModels;

public class GetAllModelsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllModelsQuery, ResultDto<List<ModelDto>>>
{
    public async Task<ResultDto<List<ModelDto>>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
    {
        var models = await unitOfWork.Models.GetAllAsync();
        
        var modelDtos = mapper.Map<List<ModelDto>>(models);
        
        return ResultDto<List<ModelDto>>.Success(modelDtos);
    }
}