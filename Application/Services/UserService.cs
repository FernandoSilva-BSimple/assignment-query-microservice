using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IUserRepository userRepository, IUserFactory userFactory)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userFactory = userFactory;
    }

    public async Task<Result<UserDTO>> AddConsumedUserAsync(Guid id, string name, string email)
    {
        var newUser = _userFactory.Create(id, name, email);
        var userCreated = await _userRepository.CreateAsync(newUser);
        var userDTOCreated = _mapper.Map<UserDTO>(userCreated);
        return Result<UserDTO>.Success(userDTOCreated);
    }


}