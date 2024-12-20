namespace MyBurger.WebAPI.Models;

public class OrderedMenuProduct
{
    public OrderedMenuProduct()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid OrderedMenuId { get; set; }
    public OrderedMenu? OrderedMenu { get; set; }
    public ICollection<UnorderedIngrediant>? UnorderedIngrediant { get; set; }
}
