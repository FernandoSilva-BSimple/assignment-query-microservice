using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface IDeviceRepository
{
    Task<IDevice?> GetByIdAsync(Guid id);
    Task<IDevice> GetAllAsync();
    Task<IDevice> CreateAsync(ICollaborator collaborator);
}
