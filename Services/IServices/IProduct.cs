using Inventory.Model;

namespace Inventory.Services.IServices
{
    public interface IProduct
    {
       
        Task<Product> GetProduct(Guid id);
        Task<string> AddProduct(Product product);
        Task<string> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<List<Product>> GetAllProducts(int page, int pageSize);
        List<Product> FilterProducts(string productName, decimal? price);
        Task<List<Product>> GetAllProductsAsync(int page, int pageSize)
    }

}
