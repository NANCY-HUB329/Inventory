using Inventory.Model;

namespace Inventory.Services.IServices
{
    public interface IUser

    {
        Task<User> GetUserByEmail(string email);
        Task<string> RegisterUser(User user);
    }
}
