namespace MyBurger.WebAPI.Models;

public class UnorderedIngrediant
{
    public UnorderedIngrediant()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid OrderedMenuProductId { get; set; }
    public OrderedMenuProduct? OrderedMenuProduct { get; set; }
    public Guid IngrediantId { get; set; }
    public Ingrediant? Ingrediant { get; set; }
}
