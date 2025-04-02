using PCDevicesShop.BLL.Interfaces;

namespace PCDevicesShop.API.Adapters
{
    public class WebHostEnvironmentAdapter: IImagePath
    {
        private readonly IWebHostEnvironment _environment;

        public WebHostEnvironmentAdapter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string UploadPath => _environment.WebRootPath;
    }
}
