using AutoMapper;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.Mappers
{
    public class LoginDtoToUserMapper:Profile
    {
        public LoginDtoToUserMapper()
        {
            CreateMap<RegisterDTO, User>();
        }
    }
}
