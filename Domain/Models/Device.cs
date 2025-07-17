using Domain.Interfaces;

namespace Domain.Models;

public class Device : IDevice
{
    public Guid Id { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceBrand { get; set; }
    public string DeviceModel { get; set; }
    public string DeviceSerialNumber { get; set; }


    public Device(Guid id, string deviceDescription, string deviceBrand, string deviceModel, string deviceSerialNumber)
    {
        Id = id;
        DeviceDescription = deviceDescription;
        DeviceBrand = deviceBrand;
        DeviceModel = deviceModel;
        DeviceSerialNumber = deviceSerialNumber;
    }
}