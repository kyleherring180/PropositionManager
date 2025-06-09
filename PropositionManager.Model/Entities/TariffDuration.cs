using PropositionManager.Model.Enums;

namespace PropositionManager.Model.Entities;

public class TariffDuration
{
    public int Id { get; init; }
    public TariffDurationUnit TariffDurationUnit { get; private set; }
    public int Quantity { get; private set; }
    
    private TariffDuration() { /*Required for EF Core */ }
    
    public TariffDuration(TariffDurationUnit tariffDurationUnit, int quantity)
    {
        TariffDurationUnit = tariffDurationUnit;
        Quantity = quantity;
    }
}