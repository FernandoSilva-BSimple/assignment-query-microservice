using Domain.Interfaces;
using Domain.Visitor;

public interface ICollaboratorFactory
{
    ICollaborator Create(ICollaboratorVisitor visitor);
    ICollaborator Create(Guid id, Guid userId);
}