using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class UserCreatedConsumer : IConsumer<UserCreatedMessage>
{
    private readonly IUserService _userService;

    public UserCreatedConsumer(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Consume(ConsumeContext<UserCreatedMessage> context)
    {
        var message = context.Message;

        await _userService.AddConsumedUserAsync(message.Id, message.Names, message.Email);
    }
}