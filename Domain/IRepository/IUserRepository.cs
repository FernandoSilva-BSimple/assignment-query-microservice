using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task<IUser?> GetByIdAsync(Guid id);
    Task<IUser> GetAllAsync();
    Task<IUser> CreateAsync(ICollaborator collaborator);
}
