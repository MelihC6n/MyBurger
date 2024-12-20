using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class BR_Menu_ProductRepository : Repository<BR_Menu_Product>
{
    public BR_Menu_ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
