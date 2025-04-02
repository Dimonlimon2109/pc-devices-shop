using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.Models
{
    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
