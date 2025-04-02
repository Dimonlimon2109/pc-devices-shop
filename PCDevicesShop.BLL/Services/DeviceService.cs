

using AutoMapper;
using FluentValidation;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.DAL.Entities;
using PCDevicesShop.DAL.Interfaces;

namespace PCDevicesShop.BLL.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDeviceDTO> _creatingDeviceValidator;
        private readonly IValidator<UpdateDeviceDTO> _updateDeviceValidator;
        private readonly ImageService _imageService;

        public DeviceService(
            IDeviceRepository deviceRepository,
            IMapper mapper,
            IValidator<CreateDeviceDTO> creatingDeviceValidator,
            IValidator<UpdateDeviceDTO> updateDeviceValidator,
            ImageService imageService)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _creatingDeviceValidator = creatingDeviceValidator;
            _updateDeviceValidator = updateDeviceValidator;
            _imageService = imageService;
        }

        public async Task<DeviceDTO> CreateDeviceAsync(CreateDeviceDTO creatingDevice, CancellationToken ct = default)
        {
            var validationResult = _creatingDeviceValidator.Validate(creatingDevice);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var device = _mapper.Map<Device>(creatingDevice);
            if (creatingDevice != null)
            {
                device.ImagePath = await _imageService.UploadImageAsync(creatingDevice.Image, ct);
            }
            
            await _deviceRepository.AddAsync(device, ct);

            return _mapper.Map<DeviceDTO>(device);
        }

        public async Task<IEnumerable<DeviceDTO>> GetAllDevicesAsync(CancellationToken ct = default)
        {
            var devices = await _deviceRepository.GetAllAsync(ct);
            return devices.Select(_mapper.Map<DeviceDTO>);
        }

        public async Task<DeviceDTO> GetDeviceByIdAsync(Guid id, CancellationToken ct = default)
        {
            var device = await _deviceRepository.GetByIdAsync(id, ct);
            return _mapper.Map<DeviceDTO>(device);
        }

        public async Task DeleteDeviceAsync(Guid deviceId, CancellationToken ct = default)
        {
            await _deviceRepository.DeleteAsync(deviceId, ct);
        }

        public async Task UpdateDeviceAsync(Guid deviceId, UpdateDeviceDTO updatingDevice, CancellationToken ct = default)
        {
            var validationResult = _updateDeviceValidator.Validate(updatingDevice);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var device = await _deviceRepository.GetByIdAsync(deviceId);
            if (device == null)
            {
                throw new NullReferenceException("Девайс не найден");
            }
            string imagePath = await _imageService.UploadImageAsync(updatingDevice.Image, ct);
            device.Name = updatingDevice.Name;
            device.Description = updatingDevice.Description;
            device.Price = updatingDevice.Price;
            device.StockQuantity = updatingDevice.StockQuantity;
            device.ImagePath = imagePath;
            device.Category = updatingDevice.Category;

            await _deviceRepository.UpdateAsync(device, ct);
        }
    }
}
