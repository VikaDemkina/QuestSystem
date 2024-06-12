using System.Text.Json;
using Confluent.Kafka;
using MediatR;
using QuestSystem.Application.DTOs;
using QuestSystem.Application.Services;
using QuestSystem.Domain.Aggregates;
using QuestSystem.Domain.Messages;
using QuestSystem.Infrastructure;

namespace QuestSystem.Domain.Events;

public record GeneratorQuestCommand(BookingDto BookingDto) : IRequest<Quest>;


public class GeneratorQuestCommandHandler(IUserService userService,QuestDbContext context,IProducer<Null, string> producer) : IRequestHandler<GeneratorQuestCommand,Quest>
{
    private readonly QuestDbContext _context=context;
    private readonly IProducer<Null, string> _producer = producer;
    private const string Topic = "addNewBooking";
    
    public async Task<Quest> Handle(GeneratorQuestCommand request, CancellationToken cancellationToken)
    {
        /*var visitedQuests = _context.UserQuests.Where(u => u.UserId == Guid.Parse(request.BookingDto.userId))
            .Select(x => x.Quest.Id);
        var availableQuests = _context.Quests.Where(x=>!visitedQuests.Contains(x.Id));
        
        int index = new Random().Next(availableQuests.Count());
        var generatedQuest = availableQuests.ToList()[index];
        var newBooking = new Booking(request.BookingDto.userId,generatedQuest.Name, generatedQuest.Address, request.BookingDto.BookingDate,"12345", generatedQuest.Price);
        context.Bookings.Add(newBooking);
        await context.SaveChangesAsync();*/
        
        var message = new Message<Null, string>
        {
            Value = JsonSerializer.Serialize(new NewBookingMessage("2024.06.13","122", System.DateTime.UtcNow.Subtract(new System.DateTime(1970,1,1)).TotalSeconds.ToString()))
        };
        await _producer.ProduceAsync(Topic, message);
        
        //return generatedQuest;
        return new Quest();
    }
}
