using QuestSystem.Application.DTOs;
using QuestSystem.Domain.Aggregates;

namespace QuestSystem.Application.Services;

public interface IUserService
{
    public Task<User> AddUser(UserInputDto userDto);
}