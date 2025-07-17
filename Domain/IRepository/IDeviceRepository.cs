using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface IDeviceRepository
{
    Task<IDevice?> GetByIdAsync(Guid id);
    Task<IEnumerable<IDevice>> GetAllAsync();
    Task<IDevice> CreateAsync(IDevice device);
}
