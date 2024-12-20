using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class IngrediantRepository : Repository<Ingrediant>
{
    public IngrediantRepository(ApplicationDbContext context) : base(context)
    {
    }
}
