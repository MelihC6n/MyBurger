namespace MyBurger.WebAPI.Models;

public sealed class BR_Product_Ingrediant
{
    public BR_Product_Ingrediant()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid IngrediantId { get; set; }
    public Ingrediant? Ingrediant { get; set; }
}