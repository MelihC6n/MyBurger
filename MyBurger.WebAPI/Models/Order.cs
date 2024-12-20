namespace MyBurger.WebAPI.Models;

public class Order
{
    public Order()
    {
        Id = Guid.NewGuid();
        OrderDate = DateTime.Now;
    }
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalPrice { get; set; }
    public ICollection<OrderedMenu>? OrderedMenu { get; set; }
}
