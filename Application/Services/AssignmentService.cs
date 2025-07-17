using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;

    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository, ICollaboratorRepository collaboratorRepository, IUserRepository userRepository, IDeviceRepository deviceRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
        _collaboratorRepository = collaboratorRepository;
        _userRepository = userRepository;
        _deviceRepository = deviceRepository;
    }

    public async Task<Result<AssignmentDTO>> AddConsumedDeviceAsync(AssignmentDTO assignmentDTO)
    {
        IAssignment assignment = _mapper.Map<Assignment>(assignmentDTO);
        var assignmentCreated = await _assignmentRepository.AddAsync(assignment);
        var assignmentDTOCreated = _mapper.Map<AssignmentDTO>(assignmentCreated);
        return Result<AssignmentDTO>.Success(assignmentDTOCreated);
    }

    public async Task<Result<AssignmentDTO>> UpdateConsumedDeviceAsync(AssignmentDTO assignmentDTO)
    {
        IAssignment assignment = _mapper.Map<Assignment>(assignmentDTO);
        var assignmentUpdated = await _assignmentRepository.UpdateAsync(assignment);
        var assignmentDTOUpdated = _mapper.Map<AssignmentDTO>(assignmentUpdated);
        return Result<AssignmentDTO>.Success(assignmentDTOUpdated);
    }

    public async Task<Result<AssignmentDTO>> GetByIdAsync(Guid id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment == null) return Result<AssignmentDTO>.Failure(Error.NotFound("Assignment not found."));

        var assignmentDTO = _mapper.Map<AssignmentDTO>(assignment);
        return Result<AssignmentDTO>.Success(assignmentDTO);
    }

    public async Task<Result<IEnumerable<AssignmentDTO>>> GetByDeviceIdAsync(Guid deviceId)
    {
        var assignments = await _assignmentRepository.GetByDeviceIdAsync(deviceId);
        if (assignments == null) return Result<IEnumerable<AssignmentDTO>>.Failure(Error.NotFound("Assignments not found."));

        var assignmentsDTO = assignments.Select(_mapper.Map<AssignmentDTO>);
        return Result<IEnumerable<AssignmentDTO>>.Success(assignmentsDTO);
    }

    public async Task<Result<IEnumerable<AssignmentDTO>>> GetByCollaboratorIdAsync(Guid collaboratorId)
    {
        var assignments = await _assignmentRepository.GetByCollaboratorIdAsync(collaboratorId);
        if (assignments == null) return Result<IEnumerable<AssignmentDTO>>.Failure(Error.NotFound("Assignments not found."));

        var assignmentsDTO = assignments.Select(_mapper.Map<AssignmentDTO>);
        return Result<IEnumerable<AssignmentDTO>>.Success(assignmentsDTO);
    }

    public async Task<Result<IEnumerable<AssignmentDTO>>> GetByPeriodDateAsync(PeriodDate periodDate)
    {
        var assignments = await _assignmentRepository.GetByPeriodDateAsync(periodDate);
        if (assignments == null) return Result<IEnumerable<AssignmentDTO>>.Failure(Error.NotFound("Assignments not found."));

        var assignmentsDTO = assignments.Select(_mapper.Map<AssignmentDTO>);
        return Result<IEnumerable<AssignmentDTO>>.Success(assignmentsDTO);
    }

    public async Task<Result<IEnumerable<AssignmentDTO>>> GetAllAsync()
    {
        var assignments = await _assignmentRepository.GetAllAsync();

        var assignmentsDTO = assignments.Select(_mapper.Map<AssignmentDTO>);
        return Result<IEnumerable<AssignmentDTO>>.Success(assignmentsDTO);
    }

    public async Task<Result<AssignmentDetailsDTO>> GetAssignmentDetailsAsync(Guid id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment == null) throw new Exception("Assignment not found.");

        var collaborator = await _collaboratorRepository.GetByIdAsync(assignment.CollaboratorId);
        if (collaborator == null) throw new Exception("Collaborator not found.");

        var user = await _userRepository.GetByIdAsync(collaborator.UserId);
        if (user == null) throw new Exception("User not found.");

        var device = await _deviceRepository.GetByIdAsync(assignment.DeviceId);
        if (device == null) throw new Exception("Device not found.");

        var detailsDTO = new AssignmentDetailsDTO(assignment.Id, device.Id, collaborator.Id, assignment.PeriodDate, user.Name, user.Email, device.DeviceDescription, device.DeviceBrand, device.DeviceModel, device.DeviceSerialNumber);

        return Result<AssignmentDetailsDTO>.Success(detailsDTO);
    }

    public async Task<Result<IEnumerable<AssignmentDetailsDTO>>> GetAllWithDetailsAsync()
    {
        var assignments = await _assignmentRepository.GetAllAsync();

        var tasks = assignments.Select(async assignment =>
        {
            var collaborator = await _collaboratorRepository.GetByIdAsync(assignment.CollaboratorId);
            if (collaborator == null) throw new Exception("Collaborator not found.");

            var user = await _userRepository.GetByIdAsync(collaborator.UserId);
            if (user == null) throw new Exception("User not found.");
            var device = await _deviceRepository.GetByIdAsync(assignment.DeviceId);
            if (device == null) throw new Exception("Device not found.");

            return new AssignmentDetailsDTO(
                assignment.Id,
                assignment.DeviceId,
                assignment.CollaboratorId,
                assignment.PeriodDate,
                user.Name,
                user.Email,
                device.DeviceDescription,
                device.DeviceBrand,
                device.DeviceModel,
                device.DeviceSerialNumber
            );
        });

        return Result<IEnumerable<AssignmentDetailsDTO>>.Success(await Task.WhenAll(tasks));
    }

}