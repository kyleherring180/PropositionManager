using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Extensions;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class PropositionPriceConfiguration : IEntityTypeConfiguration<PropositionPrice>
{
    public void Configure(EntityTypeBuilder<PropositionPrice> builder)
    {
        builder.HasKey(pp => pp.Id);
        builder.Property(pp => pp.Id).ValueGeneratedNever();
        builder.HasOne(pp => pp.Proposition).WithMany(p => p.PropositionPrices)
            .HasForeignKey(PropositionConfiguration.FkProposition);
        builder.ComplexProperty(pp => pp.PropositionPricePeriod, y => y.ConfigurePeriod());
        builder.ConfigureVersionConcurrency();
    }
}