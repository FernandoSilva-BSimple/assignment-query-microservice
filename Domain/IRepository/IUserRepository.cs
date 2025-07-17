using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface IUserRepository
{
    Task<IUser?> GetByIdAsync(Guid id);
    Task<IEnumerable<IUser>> GetAllAsync();
    Task<IUser> CreateAsync(IUser user);
}
