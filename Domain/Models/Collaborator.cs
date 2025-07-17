using Domain.Interfaces;

namespace Domain.Models;

public class Collaborator : ICollaborator
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public Collaborator(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
}