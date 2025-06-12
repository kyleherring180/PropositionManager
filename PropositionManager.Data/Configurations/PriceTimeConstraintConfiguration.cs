using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Enums;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class PriceTimeConstraintConfiguration : IEntityTypeConfiguration<PriceTimeConstraint>
{
    internal const string FkPriceTimeConstraint = "PriceTimeConstraintId";

    public void Configure(EntityTypeBuilder<PriceTimeConstraint> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.HasMany(ptc => ptc.PriceTimeConstraintPrices).WithOne().HasForeignKey(FkPriceTimeConstraint);
        builder.HasOne<DaysOfWeekEntity>().WithMany().HasForeignKey(p => p.DaysOfWeek);
    }
}


