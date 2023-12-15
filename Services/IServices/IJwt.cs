using Inventory.Model;

namespace Inventory.Services.IServices
{
    public interface IJwt
    {
        string GenerateToken(User user);
    }
}
