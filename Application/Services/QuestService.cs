using QuestSystem.Application.DTOs;
using QuestSystem.Domain.Aggregates;
using QuestSystem.Infrastructure;

namespace QuestSystem.Application.Services;

public class QuestService : IQuestService
{
    private readonly QuestDbContext _context;

    public QuestService(QuestDbContext context)
    {
        _context = context;
    }
    public async Task<Quest> AddQuest(QuestInputDto questDto)
    {
        var quest = new Quest(questDto.Name,questDto.Description, questDto.Address, questDto.Price);

        await _context.Quests.AddAsync(quest);
        await _context.SaveChangesAsync();

        return quest;
    }
}