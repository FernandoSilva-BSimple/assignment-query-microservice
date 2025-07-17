using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.AssignmentFactory;

public class CollaboratorFactory : ICollaboratorFactory
{

    public CollaboratorFactory()
    {

    }

    public ICollaborator Create(Guid id, Guid userId)
    {
        return new Collaborator(id, userId);
    }

    public ICollaborator Create(ICollaboratorVisitor visitor)
    {
        return new Collaborator(visitor.Id, visitor.UserId);
    }
}


