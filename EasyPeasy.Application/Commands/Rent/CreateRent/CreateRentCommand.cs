using MediatR;

namespace EasyPeasy.Application.Commands.Rent.CreateRent;

public class CreateRentCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}