using PCDevicesShop.BLL.Interfaces;

namespace PCDevicesShop.API.Adapters
{
    public class FormFileAdapter:IImageFile
    {
        private readonly IFormFile? _formFile;

        public FormFileAdapter(IFormFile formFile)
        {
            _formFile = formFile;
        }

        public string ContentType => _formFile.ContentType;
        public string FileName => _formFile.FileName;

        public async Task CopyToAsync(FileStream target, CancellationToken ct = default)
        {
            await _formFile.CopyToAsync(target, ct);
        }


    }
}
