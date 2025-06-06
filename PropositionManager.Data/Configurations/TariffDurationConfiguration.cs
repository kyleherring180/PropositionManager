using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class TariffDurationConfiguration : IEntityTypeConfiguration<TariffDuration>
{
    public void Configure(EntityTypeBuilder<TariffDuration> builder)
    {
        builder.HasKey(td => td.Id);
        builder.Property(td => td.Id).ValueGeneratedNever();
    }
}