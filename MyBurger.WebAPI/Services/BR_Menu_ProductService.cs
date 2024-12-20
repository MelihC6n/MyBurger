using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class BR_Menu_ProductService(BR_Menu_ProductRepository bR_Menu_ProductRepository)
{
    public async Task<List<BR_Menu_Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await bR_Menu_ProductRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(Guid menuId, Guid productId, CancellationToken cancellationToken = default)
    {
        BR_Menu_Product bR_Menu_ = new()
        {
            MenuId = menuId,
            ProductId = productId
        };
        await bR_Menu_ProductRepository.CreateAsync(bR_Menu_, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Guid menuId, Guid productId, CancellationToken cancellationToken = default)
    {
        BR_Menu_Product? bR_Menu_Product = await bR_Menu_ProductRepository.GetByIdAsync(id, cancellationToken);
        if (bR_Menu_Product is null)
        {
            throw new ArgumentException("Data is not found");
        }
        bR_Menu_Product.MenuId = menuId;
        bR_Menu_Product.ProductId = productId;
        await bR_Menu_ProductRepository.UpdateAsync(bR_Menu_Product, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        BR_Menu_Product? bR_Menu_Product = await bR_Menu_ProductRepository.GetByIdAsync(id, cancellationToken);
        if (bR_Menu_Product is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await bR_Menu_ProductRepository.DeleteAsync(bR_Menu_Product, cancellationToken);
    }
}