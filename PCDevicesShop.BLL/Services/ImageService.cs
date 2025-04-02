
using PCDevicesShop.BLL.Interfaces;

namespace PCDevicesShop.BLL.Services
{
     public class ImageService
    {

        private readonly IImagePath _environment;

        public ImageService(IImagePath environment) {
            _environment = environment;
        }

        public async Task<string> UploadImageAsync(IImageFile image, CancellationToken ct = default) {

            if (image == null)
            {
                return $"/images/default.png";
            }
            if (!IsImage(image))
            {
                throw new ArgumentException("Допустимые типы изображений: jpg, jpeg, png, webp");
            }
            var uploadFolder = Path.Combine(_environment.UploadPath, "images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var imagePath = Path.Combine(uploadFolder, uniqueFileName);
            using (FileStream fs = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(fs, ct);
            }
            return $"/images/{uniqueFileName}" ;
        }

        public bool IsImage(IImageFile image)
        {
            var mimeTypes = new[] {"image/jpg", "image/png", "image/jpeg", "image/webp" };
            return mimeTypes.Contains(image.ContentType);
        }
    }
}
