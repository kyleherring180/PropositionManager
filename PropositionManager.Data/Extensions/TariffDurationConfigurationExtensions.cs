using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Extensions;

public static class TariffDurationConfigurationExtensions
{
    public static void ConfigureTariffDuration(this ComplexPropertyBuilder<TariffDuration> complexPropertyBuilder)
    {
        complexPropertyBuilder.Property(td => td.Id);
        complexPropertyBuilder.Property(td => td.TariffDurationUnit);
        complexPropertyBuilder.Property(td => td.Quantity);
    }
}