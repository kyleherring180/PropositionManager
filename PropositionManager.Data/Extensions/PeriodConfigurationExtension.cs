using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Shared;

namespace PropositionManager.Data.Extensions;

public static class PeriodConfigurationExtension
{
    public static void ConfigurePeriod(this ComplexPropertyBuilder<Period> complexPropertyBuilder)
    {
        complexPropertyBuilder.Property(p => p.From).HasColumnName("PeriodFrom");
        complexPropertyBuilder.Property(p => p.Until).HasColumnName("PeriodUntil");
    }
}