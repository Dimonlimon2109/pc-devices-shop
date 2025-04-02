using AutoMapper;
using PCDevicesShop.API.ViewModels;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.API.Mappers
{
    public class DeviceDtoToDeviceViewModelMapper:Profile
    {
        public DeviceDtoToDeviceViewModelMapper()
        {
            CreateMap<DeviceDTO, DeviceViewModel>();
        }
    }
}
