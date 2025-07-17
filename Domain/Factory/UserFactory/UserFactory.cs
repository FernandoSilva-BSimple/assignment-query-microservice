using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.AssignmentFactory;

public class UserFactory : IUserFactory
{

    public UserFactory()
    {

    }

    public IUser Create(Guid id, string name, string email)
    {
        return new User(id, name, email);
    }

    public IUser Create(IUserVisitor visitor)
    {
        return new User(visitor.Id, visitor.Name, visitor.Email);
    }
}


