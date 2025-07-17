using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CollaboratorRepository : ICollaboratorRepository
{
    private readonly IMapper _mapper;
    private readonly AssignmentContext _context;
    private readonly ICollaboratorFactory _collaboratorFactory;

    public CollaboratorRepository(IMapper mapper, AssignmentContext context, ICollaboratorFactory collaboratorFactory)
    {
        _mapper = mapper;
        _context = context;
        _collaboratorFactory = collaboratorFactory;
    }
    public async Task<ICollaborator> CreateAsync(ICollaborator collaborator)
    {
        var collaboratorDM = _mapper.Map<CollaboratorDataModel>(collaborator);
        await _context.Set<CollaboratorDataModel>().AddAsync(collaboratorDM);
        await _context.SaveChangesAsync();
        var collaboratorAdded = _collaboratorFactory.Create(collaboratorDM);
        return collaboratorAdded;
    }

    public async Task<IEnumerable<ICollaborator>> GetAllAsync()
    {
        var collaboratorsDM = await _context.Set<CollaboratorDataModel>().ToListAsync();
        var collaborators = collaboratorsDM.Select(_collaboratorFactory.Create);
        return collaborators;

    }

    public async Task<ICollaborator?> GetByIdAsync(Guid id)
    {
        var collaboratorDM = await _context.Set<CollaboratorDataModel>().FirstOrDefaultAsync(c => c.Id == id);
        if (collaboratorDM == null) return null;

        var collaborator = _collaboratorFactory.Create(collaboratorDM);
        return collaborator;
    }

    public async Task<ICollaborator?> GetByUserIdAsync(Guid userId)
    {
        var collaboratorDM = await _context.Set<CollaboratorDataModel>().FirstOrDefaultAsync(c => c.UserId == userId);
        if (collaboratorDM == null) return null;

        var collaborator = _collaboratorFactory.Create(collaboratorDM);
        return collaborator;
    }
}