using Domain.Interfaces;
using Domain.IRepository;

namespace Infrastructure.Repositories;

public class CollaboratorRepository : ICollaboratorRepository
{
    public Task<ICollaborator> CreateAsync(ICollaborator collaborator)
    {
        throw new NotImplementedException();
    }

    public Task<ICollaborator> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollaborator?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollaborator?> GetByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}