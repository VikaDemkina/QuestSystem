using QuestSystem.Application.DTOs;
using QuestSystem.Domain.Aggregates;
using QuestSystem.Infrastructure;

namespace QuestSystem.Application.Services;

public class UserService : IUserService
{
    private readonly QuestDbContext _context;

    public UserService(QuestDbContext context)
    {
        _context = context;
    }
    public async Task<User> AddUser(UserInputDto userDto)
    {
        var user = new User(userDto.FirstName,userDto.LastName, userDto.Email);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}