using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Extensions;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

[SuppressMessage("Resharper", "InconsistentNaming")]
public class PropositionConfiguration : IEntityTypeConfiguration<Proposition>
{
    internal const string FkProposition = "PropositionId";
    
    public void Configure(EntityTypeBuilder<Proposition> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.HasMany(p => p.PropositionPrices).WithOne(pp => pp.Proposition).HasForeignKey(FkProposition);
        builder.ComplexProperty(p => p.MarketPeriod, y => y.ConfigurePeriod());
        builder.ConfigureVersionConcurrency();
        
        //Configure temporal??
    }
    
}