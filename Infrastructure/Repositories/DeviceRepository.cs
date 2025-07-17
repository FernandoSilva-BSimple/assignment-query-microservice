using Domain.Interfaces;
using Domain.IRepository;

namespace Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    public Task<IDevice> CreateAsync(ICollaborator collaborator)
    {
        throw new NotImplementedException();
    }

    public Task<IDevice> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IDevice?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}