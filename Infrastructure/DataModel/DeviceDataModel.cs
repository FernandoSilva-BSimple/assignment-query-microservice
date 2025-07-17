using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class DeviceDataModel : IDeviceVisitor
{
    public Guid Id { get; set; }

    public string DeviceDescription { get; set; }

    public string DeviceBrand { get; set; }

    public string DeviceModel { get; set; }

    public string DeviceSerialNumber { get; set; }

    public DeviceDataModel() { }

    public DeviceDataModel(IDevice device)
    {
        Id = device.Id;
        DeviceDescription = device.DeviceDescription;
        DeviceBrand = device.DeviceBrand;
        DeviceModel = device.DeviceModel;
        DeviceSerialNumber = device.DeviceSerialNumber;
    }



}
