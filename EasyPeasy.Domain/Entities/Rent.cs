using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Rent(
    Guid userId,
    Guid storePickUpId,
    Guid storeDropOffId,
    Guid? vehicleId,
    Guid? categoryId,
    StatusRent status,
    DateTime startDate,
    DateTime expectedDate,
    DateTime? returnedDate,
    float total)
    : BaseEntity
{
    public Guid UserId { get; private set; } = userId;
    public Guid StorePickUpId { get; private set; } = storePickUpId;
    public Guid StoreDropOffId { get; private set; } = storeDropOffId;
    public Guid? VehicleId { get; private set; } = vehicleId;
    public Guid? CategoryId { get; private set; } = categoryId;
    public StatusRent Status { get; set; } = status;

    public DateTime StartDate { get; private set; } = startDate;
    public DateTime ExpectedDate { get; private set; } = expectedDate;
    public DateTime? ReturnedDate { get; private set; } = returnedDate;
    public float Total { get; private set; } = total;

    public User? User { get; private set; }
    public Store? StorePickUp { get; private set; }
    public Store? StoreDropOff { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    public Category? Category { get; private set; }

    public void Update(Guid userId, Guid storePickUpId, Guid storeDropOffId, Guid? vehicleId, Guid? categoryId,
        StatusRent status, DateTime startDate, DateTime expectedDate, DateTime? returnedDate, float total)
    {
        UserId = userId;
        StorePickUpId = storePickUpId;
        StoreDropOffId = storeDropOffId;
        VehicleId = vehicleId;
        CategoryId = categoryId;
        Status = status;
        StartDate = startDate;
        ExpectedDate = expectedDate;
        ReturnedDate = returnedDate;
        Total = total;
    }
}