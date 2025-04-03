using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.DAL.Interfaces
{
    public interface IDeviceRepository:IRepository<Device>
    {
        Task<IEnumerable<Device?>> GetDevicesWithFiltersAsync(
            int page,
            int pageSize,
            string? name, DeviceCategories category,
            double? startPrice,
            double? endPrice,
            CancellationToken ct = default);
    }
}
