using MediatR;

namespace EasyPeasy.Application.Commands.Rent.CreateRent;

public class CreateRentCommand : IRequest<Guid>
{
    public Guid UserId { get; private set; }
    public Guid StorePickUpId { get; private set; }
    public Guid StoreDropOffId { get; private set; }
    public Guid? VehicleId { get; private set; }
    public Guid? CategoryId { get; private set; }
    public string Status { get; set; }

    public DateTime StartDate { get; private set; }
    public DateTime ExpectedDate { get; private set; }
    public DateTime? ReturnedDate { get; private set; }
    public float Total { get; private set; }
}