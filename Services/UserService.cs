using Inventory.Data;
using Inventory.Model;
using Inventory.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services
{


    public class UserService : IUser
    {
        private readonly InventoryContext _context;

        public UserService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<string> RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Added Successfully";
        }
    }
}
