using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class BR_Product_IngrediantService(BR_Product_IngrediantRepository bR_Product_IngrediantRepository)
{
    public async Task<List<BR_Product_Ingrediant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await bR_Product_IngrediantRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(Guid ProductId, Guid IngrediantId, CancellationToken cancellationToken = default)
    {
        BR_Product_Ingrediant bR_Product_Ingrediant = new()
        {
            ProductId = ProductId,
            IngrediantId = IngrediantId
        };
        await bR_Product_IngrediantRepository.CreateAsync(bR_Product_Ingrediant, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Guid ProductId, Guid IngrediantId, CancellationToken cancellationToken = default)
    {
        BR_Product_Ingrediant? bR_Product_Ingrediant = await bR_Product_IngrediantRepository.GetByIdAsync(id, cancellationToken);
        if (bR_Product_Ingrediant is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await bR_Product_IngrediantRepository.UpdateAsync(bR_Product_Ingrediant, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        BR_Product_Ingrediant? bR_Product_Ingrediant = await bR_Product_IngrediantRepository.GetByIdAsync(id, cancellationToken);
        if (bR_Product_Ingrediant is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await bR_Product_IngrediantRepository.DeleteAsync(bR_Product_Ingrediant);
    }
}
