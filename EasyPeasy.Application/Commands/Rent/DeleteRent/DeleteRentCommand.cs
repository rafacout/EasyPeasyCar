using MediatR;

namespace EasyPeasy.Application.Commands.Rent.DeleteRent;

public class DeleteRentCommand : IRequest<Unit>
{
    public DeleteRentCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}