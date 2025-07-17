using AutoMapper;
using Domain.Factory.AssignmentFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly IMapper _mapper;
    private readonly AssignmentContext _context;
    private readonly IAssignmentFactory _assignmentFactory;

    public AssignmentRepository(IMapper mapper, AssignmentContext context, IAssignmentFactory assignmentFactory)
    {
        _mapper = mapper;
        _context = context;
        _assignmentFactory = assignmentFactory;
    }

    public async Task<IAssignment?> GetByIdAsync(Guid id)
    {
        var assignmentDM = await _context.Set<AssignmentDataModel>().FirstOrDefaultAsync(a => a.Id == id);
        if (assignmentDM == null) return null;

        var assignment = _assignmentFactory.Create(assignmentDM);
        return assignment;
    }

    public async Task<IEnumerable<IAssignment>> GetAllAsync()
    {
        var assignmentsDM = await _context.Set<AssignmentDataModel>().ToListAsync();
        var assignments = assignmentsDM.Select(_assignmentFactory.Create);
        return assignments;
    }

    public async Task<IAssignment> AddAsync(IAssignment assignment)
    {
        var assignmentDM = _mapper.Map<AssignmentDataModel>(assignment);
        await _context.Set<AssignmentDataModel>().AddAsync(assignmentDM);
        await _context.SaveChangesAsync();
        var assignmentAdded = _assignmentFactory.Create(assignmentDM);
        return assignmentAdded;
    }

    public async Task<IAssignment> UpdateAsync(IAssignment assignment)
    {
        var assignmentDM = _mapper.Map<AssignmentDataModel>(assignment);
        _context.Set<AssignmentDataModel>().Update(assignmentDM);
        await _context.SaveChangesAsync();
        var assignmentUpdated = _assignmentFactory.Create(assignmentDM);
        return assignmentUpdated;
    }

    public async Task<IEnumerable<IAssignment>> GetByCollaboratorIdAsync(Guid collaboratorId)
    {
        var assignmentsDM = await _context.Set<AssignmentDataModel>().Where(a => a.CollaboratorId == collaboratorId).ToListAsync();
        var assignments = assignmentsDM.Select(_assignmentFactory.Create);
        return assignments;
    }

    public async Task<IEnumerable<IAssignment>> GetByDeviceIdAsync(Guid deviceId)
    {
        var assignmentsDM = await _context.Set<AssignmentDataModel>().Where(a => a.DeviceId == deviceId).ToListAsync();
        var assignments = assignmentsDM.Select(_assignmentFactory.Create);
        return assignments;
    }

    public async Task<IEnumerable<IAssignment>> GetByPeriodDateAsync(PeriodDate periodDate)
    {
        var assignmentsDM = await _context.Set<AssignmentDataModel>().Where(a => a.PeriodDate.Intersects(periodDate)).ToListAsync();
        var assignments = assignmentsDM.Select(_assignmentFactory.Create);
        return assignments;
    }
}
