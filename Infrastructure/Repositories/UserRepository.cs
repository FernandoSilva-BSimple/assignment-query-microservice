using Domain.Interfaces;
using Domain.IRepository;

public class UserRepository : IUserRepository
{
    public Task<IUser> CreateAsync(ICollaborator collaborator)
    {
        throw new NotImplementedException();
    }

    public Task<IUser> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IUser?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}