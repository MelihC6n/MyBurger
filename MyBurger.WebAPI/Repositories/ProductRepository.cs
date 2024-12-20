using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
