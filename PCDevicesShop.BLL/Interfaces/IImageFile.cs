using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCDevicesShop.BLL.Interfaces
{
    public interface IImageFile
    {
        string ContentType {  get; }
        string FileName { get; }
        public Task CopyToAsync(FileStream target, CancellationToken ct = default);
    }
}
