namespace QuestSystem.Domain.Aggregates;

public class UserQuest
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid QuestId { get; set; }
    public virtual Quest Quest { get; set; }

}