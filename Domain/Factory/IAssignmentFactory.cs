using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.AssignmentFactory;

public interface IAssignmentFactory
{
    IAssignment Create(Guid id, Guid deviceId, Guid collaboratorId, PeriodDate periodDate);
    IAssignment Create(IAssignmentVisitor visitor);

}