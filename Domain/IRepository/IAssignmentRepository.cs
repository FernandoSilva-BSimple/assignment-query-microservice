using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository;

public interface IAssignmentRepository
{
    Task<IEnumerable<IAssignment>> GetByPeriodDateAsync(PeriodDate periodDate);
    Task<IAssignment?> GetByIdAsync(Guid id);
    Task<IAssignment> UpdateAsync(IAssignment assignment);
    Task<IEnumerable<IAssignment>> GetAllAsync();
    Task<IAssignment> AddAsync(IAssignment assignment);
    Task<IEnumerable<IAssignment>> GetByCollaboratorIdAsync(Guid collaboratorId);
    Task<IEnumerable<IAssignment>> GetByDeviceIdAsync(Guid deviceId);

}
