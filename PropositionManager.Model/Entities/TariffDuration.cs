using PropositionManager.Model.Enums;

namespace PropositionManager.Model.Entities;

public class TariffDuration
{
    public int Id { get; init; }
    public TariffDurationUnit TariffDurationUnit { get; private set; }
    public int Quantity { get; private set; }
}