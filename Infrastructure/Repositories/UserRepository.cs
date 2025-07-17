using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly AssignmentContext _context;
    private readonly IUserFactory _userFactory;

    public UserRepository(IMapper mapper, AssignmentContext context, IUserFactory userFactory)
    {
        _mapper = mapper;
        _context = context;
        _userFactory = userFactory;
    }
    public async Task<IUser> CreateAsync(IUser user)
    {
        var userDM = _mapper.Map<UserDataModel>(user);
        await _context.Set<UserDataModel>().AddAsync(userDM);
        await _context.SaveChangesAsync();
        var userAdded = _userFactory.Create(userDM);
        return userAdded;
    }

    public async Task<IEnumerable<IUser>> GetAllAsync()
    {
        var usersDM = await _context.Set<UserDataModel>().ToListAsync();
        var users = usersDM.Select(_userFactory.Create);
        return users;
    }

    public async Task<IUser?> GetByIdAsync(Guid id)
    {
        var userDM = await _context.Set<UserDataModel>().FirstOrDefaultAsync(u => u.Id == id);
        if (userDM == null) return null;
        var user = _userFactory.Create(userDM);
        return user;
    }
}