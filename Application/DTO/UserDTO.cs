using Domain.Interfaces;
using Domain.Models;

namespace Application.DTO;

public record UserDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }

    public UserDTO(IUser user) => (Id, Name, Email) = (user.Id, user.Name, user.Email);

    public UserDTO() { }
}