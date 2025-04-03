using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Data;
using PCDevicesShop.DAL.Entities;
using PCDevicesShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.DAL.Repositories
{
    public class DeviceRepository:Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(ApplicationContext context) : base(context) { }

        public async Task<IEnumerable<Device?>> GetDevicesWithFiltersAsync(
            int page,
            int pageSize,
            string? name,
            DeviceCategories category,
            double? startPrice,
            double? endPrice,
            CancellationToken ct = default)
        {
            var devices = _dbSet.AsNoTracking().AsQueryable();
            if(name is not null)
            {
                devices = _dbSet.Where(d => d.Name.Contains(name));
            }
            if(category != DeviceCategories.None)
            {
                devices = _dbSet.Where(d => d.Category == category);
            }
            if(startPrice is not null && endPrice is not null)
            {
                devices = _dbSet.Where(d => d.Price >= startPrice && d.Price <= endPrice);
            }
            if(startPrice is not null && endPrice is null)
            {
                devices = _dbSet.Where(d => d.Price >= startPrice);
            }
            if (startPrice is null && endPrice is not null)
            {
                devices = _dbSet.Where(d => d.Price <= endPrice);
            }
            devices = devices.Skip((page - 1) * pageSize).Take(pageSize);
            return await devices.ToListAsync(ct);
        }
    }
}
