using System.Net.Sockets;

namespace QuestSystem.Domain.Aggregates;

public class Booking : Entity
{
    public Guid UserId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public DateTime DateBooking { get; private set; } = default!;
    public OrderNumber OrderNumber { get; private set; } = default!;
    public FinalPrice Price { get; private set; } = default!;

    public Booking()
    {
        
    }
    public Booking(string userId, string name, string address, string dateBooking, string orderNumber, decimal price)
    {
        Id = Guid.NewGuid();
        UserId = Guid.Parse(userId);
        Name = name;
        Address = new Address(address);
        DateBooking = new DateTime(dateBooking);
        OrderNumber = new OrderNumber(orderNumber);
        Price = new FinalPrice(price);
    }
}