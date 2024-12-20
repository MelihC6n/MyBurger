using Microsoft.EntityFrameworkCore;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<BR_Menu_Product> BR_Menu_Product { get; set; }
    public DbSet<BR_Product_Ingrediant> BR_Product_Ingrediant { get; set; }
    public DbSet<Ingrediant> Ingrediants { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedMenu> OrderedMenus { get; set; }
    public DbSet<OrderedMenuProduct> OrderedMenuProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<UnorderedIngrediant> UnorderedIngrediants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Menu>().Property(x => x.Price).HasColumnType("money");

        modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("money");

        modelBuilder.Entity<Order>().Property(x => x.TotalPrice).HasColumnType("money");

        modelBuilder.Entity<BR_Product_Ingrediant>().HasKey(br => new { br.IngrediantId, br.ProductId });

        modelBuilder.Entity<UnorderedIngrediant>().HasKey(unIng => new { unIng.IngrediantId, unIng.OrderedMenuProductId });
    }
}
