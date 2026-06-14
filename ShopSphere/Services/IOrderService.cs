using ShopSphere.Models;

namespace ShopSphere.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int userId);

        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
