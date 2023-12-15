using Inventory.Data;
using Inventory.Model;
using Inventory.Services.IServices;
using Microsoft.EntityFrameworkCore;
namespace Inventory.Services
{
    public class OrderService : IOrder
    {
        private readonly InventoryContext _context;

        public OrderService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<string> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return "Order Added Successfully";
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
        }

        public Task<Order> GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return "Order Updated Successfully";
        }
    }
}



