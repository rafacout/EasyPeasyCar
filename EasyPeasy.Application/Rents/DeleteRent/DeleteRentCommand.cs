using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Rents.DeleteRent;

public class DeleteRentCommand(Guid id) : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = id;
}