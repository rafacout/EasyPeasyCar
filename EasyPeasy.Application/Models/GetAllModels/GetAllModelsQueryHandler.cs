using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Models.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.GetAllModels;

public class GetAllModelsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllModelsQuery, ResultViewModel<List<ModelViewModel>>>
{
    public async Task<ResultViewModel<List<ModelViewModel>>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
    {
        var models = await unitOfWork.Models.GetAllAsync();
        
        var modelDtos = mapper.Map<List<ModelViewModel>>(models);
        
        return ResultViewModel<List<ModelViewModel>>.Success(modelDtos);
    }
}