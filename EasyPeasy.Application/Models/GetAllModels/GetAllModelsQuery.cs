using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Models.DTOs;
using MediatR;

namespace EasyPeasy.Application.Models.GetAllModels;

public class GetAllModelsQuery : IRequest<ResultViewModel<List<ModelViewModel>>>
{
}