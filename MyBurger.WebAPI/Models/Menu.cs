namespace MyBurger.WebAPI.Models;

public sealed class Menu
{
    public Menu()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; } = default;
    public string ImageUrl { get; set; } = default!;
    public ICollection<BR_Menu_Product>? bR_Menu_Products { get; set; }
    public ICollection<OrderedMenu>? OrderedMenu { get; set; }

    //00000000-0000-0000-0000-000000000000
}
