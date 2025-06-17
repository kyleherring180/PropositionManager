using PropositionManager.Contracts.v1.Enums;

namespace PropositionManager.Contracts.v1.Response;

public class TariffDuration
{
    public int Id { get; init; }
    public TariffDurationUnit TariffDurationUnit { get; set; }
    public int Quantity { get; set; }
}