namespace EasyPeasy.Domain.Entities;

public class Rent : BaseEntity
{
    public Rent(User user, Store store, Vehicle vehicle, DateTime rentDate, DateTime returnDate, decimal total)
    {
        User = user;
        Store = store;
        Vehicle = vehicle;
        RentDate = rentDate;
        ReturnDate = returnDate;
        Total = total;
    }
    public User User { get; set; }
    public Store Store { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal Total { get; set; }
    
    public void Update(User user, Store store, Vehicle vehicle, DateTime rentDate, DateTime returnDate, decimal total)
    {
        User = user;
        Store = store;
        Vehicle = vehicle;
        RentDate = rentDate;
        ReturnDate = returnDate;
        Total = total;
    }
}