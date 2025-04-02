using AutoMapper;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.Mappers
{
    public class DeviceToDeviceDtoMapper : Profile
    {
        public DeviceToDeviceDtoMapper()
        {
            CreateMap<Device, DeviceDTO>();
        }
    }
}
