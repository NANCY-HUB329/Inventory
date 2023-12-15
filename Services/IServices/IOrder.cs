using Inventory.Model;

namespace Inventory.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(Guid id);
        Task<string> AddOrder(Order order);
        Task<string> UpdateOrder(Order order);
        Task<bool> DeleteOrder(Order order);
    }
}
