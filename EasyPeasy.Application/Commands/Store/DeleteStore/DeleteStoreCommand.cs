using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Commands.Store.DeleteStore;

public class DeleteStoreCommand(Guid id) : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; } = id;
}