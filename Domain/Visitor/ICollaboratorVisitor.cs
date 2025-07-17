using Domain.Models;

namespace Domain.Visitor;

public interface ICollaboratorVisitor
{
    public Guid Id { get; }
    public Guid UserId { get; }
}