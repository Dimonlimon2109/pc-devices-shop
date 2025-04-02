using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.API.Models
{
    public record CreateDeviceModel
        (
        string Name,
        DeviceCategories Category,
        double Price, 
        int StockQuantity,
        string Description,
        IFormFile? Image
        );
}
