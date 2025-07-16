using Domain.Models;

namespace Domain.Visitor;

public interface IAssignmentVisitor
{
    public Guid Id { get; }
    public Guid DeviceId { get; }
    public Guid CollaboratorId { get; }
    public PeriodDate PeriodDate { get; }
}