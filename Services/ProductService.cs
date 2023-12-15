using Inventory.Data;
using Inventory.Model;
using Inventory.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services
{
    public class ProductService : IProduct
    {
        private readonly InventoryContext _context;

        public ProductService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<string> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return "Product Added Successfully";
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<Product> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return "Product Updated Successfully";
        }
    }
}
