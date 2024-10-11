using EasyPeasy.Application.DTOs;
using MediatR;

namespace EasyPeasy.Application.Rents.UpdateRent;

public class UpdateRentCommand : IRequest<ResultDto<Guid>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid StorePickUpId { get; set; }
    public Guid StoreDropOffId { get; set; }
    public Guid? VehicleId { get; set; }
    public Guid? CategoryId { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpectedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public float Total { get; set; }
}