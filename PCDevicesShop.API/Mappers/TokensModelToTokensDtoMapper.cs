using AutoMapper;
using PCDevicesShop.API.Models;
using PCDevicesShop.BLL.DTO;

namespace PCDevicesShop.API.Mappers
{
    public class TokensModelToTokensDtoMapper:Profile
    {
        public TokensModelToTokensDtoMapper() {
            CreateMap<TokensModel, TokensDTO>();
        }
    }
}
