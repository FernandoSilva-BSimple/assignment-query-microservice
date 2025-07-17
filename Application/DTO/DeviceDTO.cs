using Domain.Interfaces;
using Domain.Models;

namespace Application.DTO;

public record DeviceDTO
{
    public Guid Id { get; init; }
    public string DeviceDescription { get; init; }
    public string DeviceBrand { get; init; }
    public string DeviceModel { get; init; }
    public string DeviceSerialNumber { get; init; }

    public DeviceDTO(IDevice device) => (Id, DeviceDescription, DeviceBrand, DeviceModel, DeviceSerialNumber) = (device.Id, device.DeviceDescription, device.DeviceBrand, device.DeviceModel, device.DeviceSerialNumber);

    public DeviceDTO() { }
}