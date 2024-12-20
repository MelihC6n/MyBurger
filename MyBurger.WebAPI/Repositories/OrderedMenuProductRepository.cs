using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class OrderedMenuProductRepository : Repository<OrderedMenuProduct>
{
    public OrderedMenuProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
