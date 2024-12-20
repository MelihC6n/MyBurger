using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class OrderedMenuService(OrderedMenuRepository orderedMenuRepository)
{
    public async Task<List<OrderedMenu>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await orderedMenuRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(Guid orderId, Guid menuId, CancellationToken cancellationToken = default)
    {
        OrderedMenu orderedMenu = new()
        {
            OrderId = orderId,
            MenuId = menuId
        };
        await orderedMenuRepository.CreateAsync(orderedMenu, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Guid orderId, Guid menuId, CancellationToken cancellationToken = default)
    {
        OrderedMenu? orderedMenu = await orderedMenuRepository.GetByIdAsync(id);
        if (orderedMenu is null)
        {
            throw new ArgumentException("Data is not found");
        }
        orderedMenu.OrderId = orderId;
        orderedMenu.MenuId = menuId;
        await orderedMenuRepository.UpdateAsync(orderedMenu, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        OrderedMenu? orderedMenu = await orderedMenuRepository.GetByIdAsync(id);
        if (orderedMenu is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await orderedMenuRepository.DeleteAsync(orderedMenu, cancellationToken);
    }
}