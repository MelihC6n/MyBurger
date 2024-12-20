using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class BR_Product_IngrediantRepository : Repository<BR_Product_Ingrediant>
{
    public BR_Product_IngrediantRepository(ApplicationDbContext context) : base(context)
    {
    }
}
