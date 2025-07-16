using Application.DTO;
using Application.Interfaces;
using Contracts.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class AssignmentCreatedConsumer : IConsumer<AssignmentCreatedMessage>
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentCreatedConsumer(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    public async Task Consume(ConsumeContext<AssignmentCreatedMessage> context)
    {
        var message = context.Message;
        var period = new PeriodDate(message.StartDate, message.EndDate);
        var assignmentDTO = new AssignmentDTO(message.AssignmentId, message.DeviceId, message.CollaboratorId, period);

        await _assignmentService.AddConsumedDeviceAsync(assignmentDTO);
    }
}