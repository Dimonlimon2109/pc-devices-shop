using PCDevicesShop.BLL.Interfaces;
using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.DTO
{
    public class CreateDeviceDTO
    {

        public string Name { get; set; }
        public DeviceCategories Category { get; set; }
        public double Price { get; set; }
        public byte StockQuantity { get; set; }
        public IImageFile? Image { get; set; }
        public string Description { get; set; }
    }
}
