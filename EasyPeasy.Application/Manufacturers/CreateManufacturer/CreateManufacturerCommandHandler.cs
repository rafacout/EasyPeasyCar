using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Manufacturers.CreateManufacturer;

public class CreateManufacturerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateManufacturerCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Manufacturer(request.Name, request.Country);
        
        var id = await unitOfWork.Manufacturers.CreateAsync(entity);
        
        await unitOfWork.CompleteAsync();
        
        return ResultViewModel<Guid>.Success(id, "Manufacturer created successfully");
    }
}