using PCDevicesShop.BLL.Interfaces;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.DTO
{
    public class UpdateDeviceDTO
    {
        public string Name { get; set; }
        public DeviceCategories Category { get; set; }
        public double Price { get; set; }
        public byte StockQuantity { get; set; }
        public IImageFile? Image { get; set; }
        public string Description { get; set; }
    }
}