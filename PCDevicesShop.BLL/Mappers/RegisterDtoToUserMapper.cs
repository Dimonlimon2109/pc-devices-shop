using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.BLL.Services;
using PCDevicesShop.DAL.Entities;

namespace PCDevicesShop.BLL.Mappers
{
    public class RegisterDtoToUserMapper:Profile
    {
        public RegisterDtoToUserMapper()
        {
            CreateMap<RegisterDTO, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => new PasswordService().HashPassword(src.Password)));
        }
    }
}
