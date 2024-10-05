using MediatR;

namespace EasyPeasy.Application.Commands.Store.DeleteStore;

public class DeleteStoreCommand : IRequest<Unit>
{
    public DeleteStoreCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}