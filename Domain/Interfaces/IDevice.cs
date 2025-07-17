using Domain.Models;

namespace Domain.Interfaces;

public interface IDevice
{
    public Guid Id { get; }
    public string DeviceDescription { get; }
    public string DeviceBrand { get; }
    public string DeviceModel { get; }
    public string DeviceSerialNumber { get; }
}