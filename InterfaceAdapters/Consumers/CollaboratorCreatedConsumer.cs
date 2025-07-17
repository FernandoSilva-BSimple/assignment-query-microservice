using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class CollaboratorCreatedConsumer : IConsumer<CollaboratorCreatedMessage>
{
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorCreatedConsumer(ICollaboratorService collaboratorService)
    {
        _collaboratorService = collaboratorService;
    }
    public async Task Consume(ConsumeContext<CollaboratorCreatedMessage> context)
    {
        var message = context.Message;

        await _collaboratorService.AddConsumedCollaboratorAsync(message.Id, message.UserId);
    }
}