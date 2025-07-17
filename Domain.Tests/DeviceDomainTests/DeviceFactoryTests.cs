using Domain.Factory;
using Domain.Factory.AssignmentFactory;
using Domain.IRepository;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.DeviceDomainTests;

public class DeviceFactoryTests
{
    [Fact]
    public void WhenCreatingDeviceWithValidFieldsAndId_ThenDeviceIsCreated()
    {
        //arrange
        var deviceFactory = new DeviceFactory();

        string description = "Work laptop";
        string brand = "Dell";
        string model = "Latitude 14";
        string serialNumber = "1234567890";

        //act
        var result = deviceFactory.Create(It.IsAny<Guid>(), description, brand, model, serialNumber);

        //assert
        Assert.NotNull(result);
        Assert.Equal(description, result.DeviceDescription);
        Assert.Equal(brand, result.DeviceBrand);
        Assert.Equal(model, result.DeviceModel);
        Assert.Equal(serialNumber, result.DeviceSerialNumber);
    }

    [Fact]
    public void WhenCreatingDeviceFromVisitor_ThenDeviceIsCreated()
    {
        //arrange
        var deviceFactory = new DeviceFactory();

        Mock<IDeviceVisitor> deviceVisitor = new Mock<IDeviceVisitor>();
        deviceVisitor.Setup(d => d.Id).Returns(Guid.NewGuid());
        deviceVisitor.Setup(d => d.DeviceDescription).Returns("Work laptop");
        deviceVisitor.Setup(d => d.DeviceBrand).Returns("Dell");
        deviceVisitor.Setup(d => d.DeviceModel).Returns("Latitude 14");
        deviceVisitor.Setup(d => d.DeviceSerialNumber).Returns("1234567890");

        //act
        var result = deviceFactory.Create(deviceVisitor.Object);

        //assert
        Assert.NotNull(result);
        Assert.Equal("Dell", result.DeviceBrand);
        Assert.Equal("Latitude 14", result.DeviceModel);
        Assert.Equal("1234567890", result.DeviceSerialNumber);
    }
}