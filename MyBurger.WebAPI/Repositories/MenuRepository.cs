using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class MenuRepository : Repository<Menu>
{
    public MenuRepository(ApplicationDbContext context) : base(context)
    {
    }
}
