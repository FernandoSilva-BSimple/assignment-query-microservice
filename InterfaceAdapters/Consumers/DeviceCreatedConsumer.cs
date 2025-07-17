using Application.DTO;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class DeviceCreatedConsumer : IConsumer<DeviceCreatedMessage>
{
    private readonly IDeviceService _deviceService;

    public DeviceCreatedConsumer(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }
    public async Task Consume(ConsumeContext<DeviceCreatedMessage> context)
    {
        var message = context.Message;

        await _deviceService.AddConsumedDeviceAsync(message.Id, message.Description, message.Brand, message.Model, message.SerialNumber);
    }
}