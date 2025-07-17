using Application.DTO;
using Domain.Models;

namespace Application.Interfaces;

public interface IAssignmentService
{
    Task<Result<IEnumerable<AssignmentDTO>>> GetAllAsync();
    Task<Result<IEnumerable<AssignmentDetailsDTO>>> GetAllWithDetailsAsync();
    Task<Result<AssignmentDTO>> AddConsumedDeviceAsync(AssignmentDTO assignmentDTO);
    Task<Result<AssignmentDTO>> UpdateConsumedDeviceAsync(AssignmentDTO assignmentDTO);
    Task<Result<AssignmentDTO>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<AssignmentDTO>>> GetByDeviceIdAsync(Guid deviceId);
    Task<Result<IEnumerable<AssignmentDTO>>> GetByCollaboratorIdAsync(Guid collaboratorId);
    Task<Result<IEnumerable<AssignmentDTO>>> GetByPeriodDateAsync(PeriodDate periodDate);
    Task<Result<AssignmentDetailsDTO>> GetAssignmentDetailsAsync(Guid id);

}