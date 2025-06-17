namespace PropositionManager.Model.Shared;

public record struct Period
{
    public DateTimeOffset From { get; init; }
    public DateTimeOffset? Until { get; private set; }
    
    public Period(DateTimeOffset from, DateTimeOffset? until = null)
    {
        From = from;
        Until = until;
    }
};