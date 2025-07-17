using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Factory.AssignmentFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class CollaboratorService : ICollaboratorService
{
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly ICollaboratorFactory _collaboratorFactory;
    private readonly IMapper _mapper;

    public CollaboratorService(IMapper mapper, ICollaboratorRepository collaboratorRepository, ICollaboratorFactory collaboratorFactory)
    {
        _mapper = mapper;
        _collaboratorRepository = collaboratorRepository;
        _collaboratorFactory = collaboratorFactory;
    }

    public async Task<Result<CollaboratorDTO>> AddConsumedCollaboratorAsync(Guid id, Guid userId)
    {
        var newCollab = _collaboratorFactory.Create(id, userId);
        var assignmentCreated = await _collaboratorRepository.CreateAsync(newCollab);
        var assignmentDTOCreated = _mapper.Map<CollaboratorDTO>(assignmentCreated);
        return Result<CollaboratorDTO>.Success(assignmentDTOCreated);
    }


}