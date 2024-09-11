namespace EasyPeasy.Domain.Entities;

public class RentItem : BaseEntity
{

    public Guid RentId { get; set; }

    

    public Rent Rent { get; set; }
    
}