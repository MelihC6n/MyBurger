namespace MyBurger.WebAPI.Models;

public class BR_Menu_Product
{
    public BR_Menu_Product()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public Menu? Menu { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
