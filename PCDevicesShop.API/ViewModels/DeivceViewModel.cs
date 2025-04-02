using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.API.ViewModels
{
    public class DeviceViewModel
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
