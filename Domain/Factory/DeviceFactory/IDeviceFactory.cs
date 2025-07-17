using Domain.Interfaces;
using Domain.Visitor;

public interface IDeviceFactory
{
    IDevice Create(IDeviceVisitor visitor);
    IDevice Create(Guid id, string deviceDescription, string deviceBrand, string deviceModel, string deviceSerialNumber);
}