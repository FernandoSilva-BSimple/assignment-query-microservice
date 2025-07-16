using Domain.Interfaces;

namespace Domain.Models;

public class Assignment : IAssignment
{
    public Guid Id { get; private set; }
    public Guid DeviceId { get; private set; }
    public Guid CollaboratorId { get; private set; }
    public PeriodDate PeriodDate { get; private set; }

    public Assignment(Guid id, Guid deviceId, Guid collaboratorId, PeriodDate periodDate)
    {
        Id = id;
        DeviceId = deviceId;
        CollaboratorId = collaboratorId;
        PeriodDate = periodDate;
    }
}