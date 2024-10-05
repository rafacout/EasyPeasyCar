using MediatR;

namespace EasyPeasy.Application.Commands.Model.CreateModel;

public class CreateModelCommand : IRequest<Guid>
{
    public string Name { get;  set; }
    public int Year { get;  set; }
    public Guid ManufacturerId { get;  set; }
    public Guid CategoryId { get;  set; }
    public string Transmission { get;  set; }
    public string Motor { get;  set; }
}