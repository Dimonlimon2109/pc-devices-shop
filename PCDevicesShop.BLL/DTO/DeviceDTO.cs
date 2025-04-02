using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.DTO
{
    public class DeviceDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DeviceCategories Category { get; set; }
        public double Price { get; set; }
        public byte StockQuantity { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
