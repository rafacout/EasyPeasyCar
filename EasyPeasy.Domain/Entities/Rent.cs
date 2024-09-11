using EasyPeasy.Domain.Enum;

namespace EasyPeasy.Domain.Entities;

public class Rent : BaseEntity
{
    public Rent(Guid userId, Guid storePickUpId, Guid storeDropOffId, Guid? vehicleId, Guid? categoryId, StatusRent status, DateTime startDate, DateTime expectedDate, DateTime? returnedDate, float total)
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

    public Guid UserId { get; private set; }
    public Guid StorePickUpId { get; private set; }
    public Guid StoreDropOffId { get; private set; }
    public Guid? VehicleId { get; private set; }
    public Guid? CategoryId { get; private set; }
    public StatusRent Status { get; set; }
    
    public DateTime StartDate { get; private set; }
    public DateTime ExpectedDate { get; private set; }
    public DateTime? ReturnedDate { get; private set; }
    public float Total { get; private set; }
    
    public User User { get; private set; }
    public Store StorePickUp { get; private set; }
    public Store StoreDropOff { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    public Category Category { get; private set; }

}