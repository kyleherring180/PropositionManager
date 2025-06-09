using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Enums;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class TariffDurationConfiguration : IEntityTypeConfiguration<TariffDuration>
{
    internal const string FkTariffDuration = "TariffDurationId";
        
    public void Configure(EntityTypeBuilder<TariffDuration> builder)
    {
        builder.HasKey(td => td.Id);
        builder.Property(td => td.Id).UseIdentityColumn();
        builder.HasOne<TariffDurationUnitEntity>().WithMany().HasForeignKey(td => td.TariffDurationUnit);
    }
}