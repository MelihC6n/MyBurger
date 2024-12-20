using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class OrderRepository : Repository<Order>
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}
