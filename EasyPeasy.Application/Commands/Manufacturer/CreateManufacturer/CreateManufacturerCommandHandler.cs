using EasyPeasy.Application.DTOs;
using EasyPeasy.Infrastructure.Persistence.Repositories;
using MediatR;

namespace EasyPeasy.Application.Commands.Manufacturer.CreateManufacturer;

public class CreateManufacturerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateManufacturerCommand, ResultDto<Guid>>
{
    public async Task<ResultDto<Guid>> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Manufacturer(request.Name, request.Country);
        
        var id = await unitOfWork.Manufacturers.CreateAsync(entity);
        
        await unitOfWork.CompleteAsync();
        
        return ResultDto<Guid>.Success(id, "Manufacturer created successfully");
    }
}