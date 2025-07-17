using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class UserDataModel : IUserVisitor
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }


    public UserDataModel() { }

    public UserDataModel(IUser user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}
