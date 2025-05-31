namespace PropositionManager.Model.Shared;

public record struct Period
{
    public DateTimeOffset From { get; init; }
    public DateTimeOffset? Until { get; private set; }
};