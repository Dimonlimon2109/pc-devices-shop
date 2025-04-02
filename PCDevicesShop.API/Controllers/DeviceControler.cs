using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCDevicesShop.API.Models;
using PCDevicesShop.API.ViewModels;
using PCDevicesShop.BLL.DTO;
using PCDevicesShop.BLL.Services;

namespace PCDevicesShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceControler : ControllerBase
    {
        private readonly DeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceControler(DeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] CreateDeviceModel creatingDevice, CancellationToken ct = default)
        {
            var createDeviceDTO = _mapper.Map<CreateDeviceDTO>(creatingDevice);
            var deviceDTO = await _deviceService.CreateDeviceAsync(createDeviceDTO, ct);
            var deviceViewModel = _mapper.Map<DeviceViewModel>(deviceDTO);
            return CreatedAtAction(nameof(CreateEvent), new { id = deviceDTO.Id }, deviceViewModel);
        }

        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetDevice(Guid id, CancellationToken ct = default)
        {
            var deviceDTO = await _deviceService.GetDeviceByIdAsync(id, ct);
            var deviceViewModel = _mapper.Map<DeviceViewModel>(deviceDTO);
            return Ok(deviceViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevices(Guid id, CancellationToken ct = default)
        {
            var devicesDTO = await _deviceService.GetAllDevicesAsync(ct);
            var devicesViewModel = devicesDTO.Select(_mapper.Map<DeviceDTO>);
            return Ok(devicesViewModel);
        }

        [HttpPut("{id:guid}")]
        //[Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateDevice(Guid id, [FromForm] UpdateDeviceModel updatingDevice, CancellationToken ct = default)
        {
            var updatingDevicesDTO = _mapper.Map<UpdateDeviceDTO>(updatingDevice);
            await _deviceService.UpdateDeviceAsync(id, updatingDevicesDTO, ct);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        //[Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteDevice(Guid id, CancellationToken ct = default)
        {
            await _deviceService.DeleteDeviceAsync(id, ct);
            return NoContent();
        }
    }
}
