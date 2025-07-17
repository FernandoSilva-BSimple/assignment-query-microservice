using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IDeviceFactory _deviceFactory;
    private readonly IMapper _mapper;

    public DeviceService(IMapper mapper, IDeviceRepository deviceRepository, IDeviceFactory deviceFactory)
    {
        _mapper = mapper;
        _deviceRepository = deviceRepository;
        _deviceFactory = deviceFactory;
    }

    public async Task<Result<DeviceDTO>> AddConsumedDeviceAsync(Guid id, string description, string brand, string model, string serialNumber)
    {
        var newDevice = _deviceFactory.Create(id, description, brand, model, serialNumber);
        var deviceCreated = await _deviceRepository.CreateAsync(newDevice);
        var deviceDTOCreated = _mapper.Map<DeviceDTO>(deviceCreated);
        return Result<DeviceDTO>.Success(deviceDTOCreated);
    }


}