using AutoMapper;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.Mappers
{
    public class CreateDeviceDtoToDeviceMapper:Profile
    {
        public CreateDeviceDtoToDeviceMapper()
        {
            CreateMap<CreateDeviceDTO, Device>();
        }
    }
}
