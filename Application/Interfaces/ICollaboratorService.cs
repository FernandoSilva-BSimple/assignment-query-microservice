using Application.DTO;

namespace Application.Interfaces;

public interface ICollaboratorService
{
    Task<Result<CollaboratorDTO>> AddConsumedCollaboratorAsync(Guid id, Guid userId);
}