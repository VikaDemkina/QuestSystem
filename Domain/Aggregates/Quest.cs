using System.Net.Sockets;

namespace QuestSystem.Domain.Aggregates;

public class Quest : Entity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public Price Price { get; private set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<UserQuest> VisitedUsers{ get; set; }

    public Quest()
    {
        
    }

    public Quest(string name, string description, string address, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Address = new Address(address);
        Price = new Price(price);
    }

    // public Quest GeneratorQuest(List<Quest> visitedQuests, List<Quest> allQuest)
    // {
    //     return new Quest();
    // }
}

// public static Quest Create(QuestId id, Name name, Description description, Address address,Price price, bool isDeleted = false)
//     {
//         var quest = new Quest
//         {
//             Id = id,
//             Name = name,
//             Description = description,
//             Address = address,
//             Price = price
//         };
//         
//
//         var @event = new QuestCreatedDomainEvent(
//                 quest.Id,
//                 quest.Name,
//                 quest.Description,
//                 quest.Address,
//                 quest.Price);
//
//             quest.AddDomainEvent(@event);
//             return quest;
//     }
// }

