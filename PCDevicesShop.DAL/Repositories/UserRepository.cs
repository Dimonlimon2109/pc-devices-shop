using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Data;
using PCDevicesShop.DAL.Entities;
using PCDevicesShop.DAL.Interfaces;

namespace PCDevicesShop.DAL.Repositories
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context):base(context) {
        }

        public async Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == userName, ct);
        }
    }
}
