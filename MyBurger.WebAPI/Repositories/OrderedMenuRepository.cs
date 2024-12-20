using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class OrderedMenuRepository : Repository<OrderedMenu>
{
    public OrderedMenuRepository(ApplicationDbContext context) : base(context)
    {
    }
}
