using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.API.Models
{
    public record UpdateDeviceModel
        (
        string Name,
        DeviceCategories Category,
        double Price,
        int StockQuantity,
        string Description,
        IFormFile? Image
        );
}
