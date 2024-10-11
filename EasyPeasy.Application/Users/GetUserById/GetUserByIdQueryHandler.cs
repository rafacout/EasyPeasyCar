using AutoMapper;
using EasyPeasy.Application.DTOs;
using EasyPeasy.Application.Users.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Users.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
{
    public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.Id);
        
        if (user == null)
        {
            return ResultViewModel<UserViewModel>.Failure($"User '{request.Id}' not exist.");
        }

        var userDto = mapper.Map<UserViewModel>(user);
        
        return ResultViewModel<UserViewModel>.Success(userDto);
    }
}