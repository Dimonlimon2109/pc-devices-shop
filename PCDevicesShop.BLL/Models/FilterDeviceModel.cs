using PCDevicesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.Models
{
    public class FilterDeviceModel
    {
        public string? Name {  get; set; }
        public DeviceCategories Category { get; set; } = DeviceCategories.None;

        public double? StartPrice { get; set; }

        public double? EndPrice { get; set; }

        public int Page {  get; set; }
        public int PageSize { get; set; }



    }
}
