using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.DAL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default);
    }
}
