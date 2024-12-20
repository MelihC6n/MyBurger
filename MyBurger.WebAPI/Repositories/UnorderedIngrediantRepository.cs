using MyBurger.WebAPI.Context;
using MyBurger.WebAPI.Models;

namespace MyBurger.WebAPI.Repositories;

public class UnorderedIngrediantRepository : Repository<UnorderedIngrediant>
{
    public UnorderedIngrediantRepository(ApplicationDbContext context) : base(context)
    {
    }
}
