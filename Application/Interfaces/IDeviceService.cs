using Application.DTO;

namespace Application.Interfaces;

public interface IDeviceService
{
    Task<Result<DeviceDTO>> AddConsumedDeviceAsync(Guid id, string description, string brand, string model, string serialNumber);
}