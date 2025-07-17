using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.AssignmentFactory;

public class DeviceFactory : IDeviceFactory
{

    public DeviceFactory()
    {

    }

    public IDevice Create(Guid id, string description, string brand, string model, string serialNumber)
    {
        return new Device(id, description, brand, model, serialNumber);
    }

    public IDevice Create(IDeviceVisitor visitor)
    {
        return new Device(visitor.Id, visitor.DeviceDescription, visitor.DeviceBrand, visitor.DeviceModel, visitor.DeviceSerialNumber);
    }
}


