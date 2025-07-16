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
    private readonly IMapper _mapper;

    public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository)
    {
        _mapper = mapper;
        _assignmentRepository = assignmentRepository;
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
}