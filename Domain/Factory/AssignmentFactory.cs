using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.AssignmentFactory;

public class AssignmentFactory : IAssignmentFactory
{

    public AssignmentFactory()
    {

    }

    public IAssignment Create(Guid id, Guid deviceId, Guid collaboratorId, PeriodDate periodDate)
    {
        return new Assignment(id, deviceId, collaboratorId, periodDate);
    }

    public IAssignment Create(IAssignmentVisitor visitor)
    {
        return new Assignment(visitor.Id, visitor.DeviceId, visitor.CollaboratorId, visitor.PeriodDate);
    }
}


