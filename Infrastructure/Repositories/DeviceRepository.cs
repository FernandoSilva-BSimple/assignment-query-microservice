using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly IMapper _mapper;
    private readonly AssignmentContext _context;
    private readonly IDeviceFactory _deviceFactory;

    public DeviceRepository(IMapper mapper, AssignmentContext context, IDeviceFactory deviceFactory)
    {
        _mapper = mapper;
        _context = context;
        _deviceFactory = deviceFactory;
    }
    public async Task<IDevice> CreateAsync(IDevice device)
    {
        var deviceDM = _mapper.Map<DeviceDataModel>(device);
        await _context.Set<DeviceDataModel>().AddAsync(deviceDM);
        await _context.SaveChangesAsync();
        var deviceAdded = _deviceFactory.Create(deviceDM);
        return deviceAdded;
    }

    public async Task<IEnumerable<IDevice>> GetAllAsync()
    {
        var devicesDM = await _context.Set<DeviceDataModel>().ToListAsync();
        var devices = devicesDM.Select(_deviceFactory.Create);
        return devices;
    }

    public async Task<IDevice?> GetByIdAsync(Guid id)
    {
        var deviceDM = await _context.Set<DeviceDataModel>().FirstOrDefaultAsync(d => d.Id == id);
        if (deviceDM == null) return null;

        var device = _deviceFactory.Create(deviceDM);
        return device;
    }
}