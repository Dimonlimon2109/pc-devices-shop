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
    }
}
