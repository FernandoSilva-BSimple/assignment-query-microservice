using Domain.Interfaces;
using Domain.Visitor;

public interface IUserFactory
{
    IUser Create(IUserVisitor visitor);
    IUser Create(Guid id, string name, string email);
}