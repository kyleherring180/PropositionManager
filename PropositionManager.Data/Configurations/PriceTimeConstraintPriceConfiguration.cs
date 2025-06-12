using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class PriceTimeConstraintPriceConfiguration : IEntityTypeConfiguration<PriceTimeConstraintPrice>
{
    public void Configure(EntityTypeBuilder<PriceTimeConstraintPrice> builder)
    {
        builder.HasKey(pt => pt.Id);
        builder.Property(pt => pt.Id).ValueGeneratedNever();
        builder.HasOne(pt => pt.PriceTimeConstraint).WithMany(pt => pt.PriceTimeConstraintPrices)
            .HasForeignKey(PriceTimeConstraintConfiguration.FkPriceTimeConstraint);
        builder.HasOne(pt => pt.Price).WithMany(p => p.PriceTimeConstraintPrices)
            .HasForeignKey(PriceConfiguration.FkPrice);
    }
}