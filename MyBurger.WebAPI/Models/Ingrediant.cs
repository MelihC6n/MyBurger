namespace MyBurger.WebAPI.Models;

public sealed class Ingrediant
{
    public Ingrediant()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<BR_Product_Ingrediant>? BR_Product_Ingrediants { get; set; }
    public ICollection<UnorderedIngrediant>? UnorderedIngrediant { get; set; }
}
