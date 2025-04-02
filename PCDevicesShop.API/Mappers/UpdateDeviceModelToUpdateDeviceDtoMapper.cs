using AutoMapper;
using PCDevicesShop.API.Adapters;
using PCDevicesShop.API.Models;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.API.Mappers
{
    public class UpdateDeviceModelToUpdateDeviceDtoMapper : Profile
    {
        public UpdateDeviceModelToUpdateDeviceDtoMapper() {
        CreateMap<UpdateDeviceModel, UpdateDeviceDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image != null ? new FormFileAdapter(src.Image) : null));
        }
    }

}
