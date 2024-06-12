using QuestSystem.Application.DTOs;
using QuestSystem.Domain.Aggregates;

namespace QuestSystem.Application.Services;

public interface IQuestService
{
    public Task<Quest> AddQuest (QuestInputDto questDto);
}