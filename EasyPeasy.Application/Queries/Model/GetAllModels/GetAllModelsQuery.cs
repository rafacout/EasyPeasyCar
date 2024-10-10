using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Queries.Model.GetAllModels;

public class GetAllModelsQuery : IRequest<ResultDto<List<ModelDto>>>
{
}