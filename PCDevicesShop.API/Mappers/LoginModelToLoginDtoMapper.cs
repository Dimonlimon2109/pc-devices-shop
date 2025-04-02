using AutoMapper;
using PCDevicesShop.API.Models;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.API.Mappers
{
    public class LoginModelToLoginDtoMapper:Profile
    {
        public LoginModelToLoginDtoMapper()
        {
            CreateMap<LoginModel, LoginDTO>();
        }
    }
}
