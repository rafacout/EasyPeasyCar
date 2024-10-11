using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Stores.UpdateStore;

public class UpdateStoreCommand : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}