namespace MyBurger.WebAPI.Models;

public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; } = default;
    public string ImageUrl { get; set; } = default!;
    public ICollection<BR_Product_Ingrediant>? BR_Product_Ingrediants { get; set; }
    public ICollection<BR_Menu_Product>? BR_Menu_Products { get; set; }
    public ICollection<OrderedMenuProduct>? OrderedMenuProduct { get; set; }
}
