using Domain.Models;

namespace Application.DTO;

public record CollaboratorDTO
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }

    public CollaboratorDTO(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }

    public CollaboratorDTO() { }
}