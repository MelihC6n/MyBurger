using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class OrderedMenuProductService(OrderedMenuProductRepository orderedMenuProductRepository)
{
    public async Task<List<OrderedMenuProduct>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await orderedMenuProductRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(Guid productId, Guid orderedMenuId, CancellationToken cancellationToken = default)
    {
        OrderedMenuProduct orderedMenuProduct = new()
        {
            ProductId = productId,
            OrderedMenuId = orderedMenuId,
        };
        await orderedMenuProductRepository.CreateAsync(orderedMenuProduct, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Guid productId, Guid orderedMenuId, CancellationToken cancellationToken = default)
    {
        OrderedMenuProduct? orderedMenuProduct = await orderedMenuProductRepository.GetByIdAsync(id, cancellationToken);
        if (orderedMenuProduct is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await orderedMenuProductRepository.UpdateAsync(orderedMenuProduct, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        OrderedMenuProduct? orderedMenuProduct = await orderedMenuProductRepository.GetByIdAsync(id, cancellationToken);
        if (orderedMenuProduct is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await orderedMenuProductRepository.DeleteAsync(orderedMenuProduct, cancellationToken);
    }
}
