namespace QuestSystem.Domain.Aggregates;

public class User : Entity
{
    public UserName UserName { get; private set; } = default!;
    public EmailAddress Email { get; private set; } = default!;
    // public List<Quest> VisitedQuests { get; private set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<UserQuest> VisitedQuests{ get; set; }

    public User()
    {
        
    }
    
    public User(string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();
        UserName = new UserName(firstName, lastName);
        Email = new EmailAddress(email);
    }
}



// public static User Create(Guid id, Username username, Email email,List<Quest> quests, bool isDeleted = false)
    // {
    //     var user = new User ()
    //     {
    //         Id = id,
    //         Username = username,
    //         Email = email,
    //         Quests = quests,
    //     };
    //     return user;
    // };
    // var @event = new UserCreatedDomainEvent (
    //     user.Id,
    //     user.Username,
    //     user.Email,
    //     user.Quests.Select(d => d.Id).ToList());
    //
    // race.AddDomainEvent(@event);
    //
    // return User;
    
    

    
    
  
