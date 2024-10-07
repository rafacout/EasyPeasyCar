using MediatR;

namespace EasyPeasy.Application.Commands.Store.CreateStore;

public class CreateStoreCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}