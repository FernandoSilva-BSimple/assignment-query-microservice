using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class AssignmentUpdatedConsumer : IConsumer<AssignmentUpdatedMessage>
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentUpdatedConsumer(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    public async Task Consume(ConsumeContext<AssignmentUpdatedMessage> context)
    {
        var message = context.Message;
        var period = new PeriodDate(message.StartDate, message.EndDate);
        var assignmentDTO = new AssignmentDTO(message.AssignmentId, message.DeviceId, message.CollaboratorId, period);

        await _assignmentService.UpdateConsumedDeviceAsync(assignmentDTO);
    }
}