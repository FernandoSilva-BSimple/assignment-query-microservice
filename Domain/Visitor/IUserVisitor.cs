using Domain.Models;

namespace Domain.Visitor;

public interface IUserVisitor
{
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
}