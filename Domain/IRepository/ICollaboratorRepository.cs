using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface ICollaboratorRepository
{
    Task<ICollaborator?> GetByIdAsync(Guid id);
    Task<ICollaborator> GetAllAsync();
    Task<ICollaborator> CreateAsync(ICollaborator collaborator);
    Task<ICollaborator?> GetByUserIdAsync(Guid userId);
}
