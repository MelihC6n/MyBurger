using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class UnorderedIngrediantService(UnorderedIngrediantRepository unorderedIngrediantRepository)
{
    public async Task<List<UnorderedIngrediant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await unorderedIngrediantRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(Guid orderedMenuProductId, Guid ingrediantId, CancellationToken cancellationToken = default)
    {
        UnorderedIngrediant unorderedIngrediant = new()
        {
            OrderedMenuProductId = orderedMenuProductId,
            IngrediantId = ingrediantId,
        };
        await unorderedIngrediantRepository.CreateAsync(unorderedIngrediant, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Guid orderedMenuProductId, Guid ingrediantId, CancellationToken cancellationToken = default)
    {
        UnorderedIngrediant? unorderedIngrediant = await unorderedIngrediantRepository.GetByIdAsync(id, cancellationToken);
        if (unorderedIngrediant is null)
        {
            throw new ArgumentException("Data is not found");
        }
        unorderedIngrediant.OrderedMenuProductId = orderedMenuProductId;
        unorderedIngrediant.IngrediantId = ingrediantId;
        await unorderedIngrediantRepository.UpdateAsync(unorderedIngrediant, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        UnorderedIngrediant? unorderedIngrediant = await unorderedIngrediantRepository.GetByIdAsync(id, cancellationToken);
        if (unorderedIngrediant is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await unorderedIngrediantRepository.DeleteAsync(unorderedIngrediant, cancellationToken);
    }
}
