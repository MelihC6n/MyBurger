using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class OrderService(OrderRepository orderRepository)
{
    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await orderRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(double totalPrice, CancellationToken cancellationToken = default)
    {
        Order order = new()
        {
            TotalPrice = totalPrice
        };
        await orderRepository.CreateAsync(order);
    }

    public async Task UpdateAsync(Guid id, double totalPrice, CancellationToken cancellationToken = default)
    {
        Order? order = await orderRepository.GetByIdAsync(id, cancellationToken);
        if (order is null)
        {
            throw new ArgumentException("Data is not found");
        }
        order.TotalPrice = totalPrice;
        order.OrderDate = DateTime.Now;
        await orderRepository.UpdateAsync(order, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Order? order = await orderRepository.GetByIdAsync(id, cancellationToken);
        if (order is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await orderRepository.DeleteAsync(order, cancellationToken);
    }
}
