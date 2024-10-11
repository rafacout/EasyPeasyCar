using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Stores.DeleteStore;

public class DeleteStoreCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}