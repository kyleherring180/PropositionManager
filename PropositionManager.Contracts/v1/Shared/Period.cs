namespace PropositionManager.Contracts.v1.Shared;

public class Period
{
    public DateTimeOffset From { get; set; }
    public DateTimeOffset? Until { get; set; }
}