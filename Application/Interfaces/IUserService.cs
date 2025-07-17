using Application.DTO;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Result<UserDTO>> AddConsumedUserAsync(Guid id, string name, string email);
}