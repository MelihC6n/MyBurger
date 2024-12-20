namespace MyBurger.WebAPI.Models;

public class OrderedMenu
{
    public OrderedMenu()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public Menu? Menu { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public ICollection<OrderedMenuProduct>? OrderedMenuProduct { get; set; }
}
