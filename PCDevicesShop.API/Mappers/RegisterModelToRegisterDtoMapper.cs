using AutoMapper;
using PCDevicesShop.API.Models;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.API.Mappers
{
    public class RegisterModelToRegisterDtoMapper:Profile
    {
        public RegisterModelToRegisterDtoMapper() {
            CreateMap<RegisterModel, RegisterDTO>();
        }
    }
}
