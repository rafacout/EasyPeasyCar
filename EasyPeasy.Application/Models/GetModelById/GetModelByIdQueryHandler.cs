using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Models.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Models.GetModelById;

public class GetModelByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetModelByIdQuery, ResultViewModel<ModelViewModel>>
{
    public async Task<ResultViewModel<ModelViewModel>> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await unitOfWork.Models.GetByIdAsync(request.Id);
        
        if (model == null)
        {
            return ResultViewModel<ModelViewModel>.Failure($"Model '{request.Id}' not exist.");
        }

        var modelDto = mapper.Map<ModelViewModel>(model);
        
        return ResultViewModel<ModelViewModel>.Success(modelDto);
    }
}