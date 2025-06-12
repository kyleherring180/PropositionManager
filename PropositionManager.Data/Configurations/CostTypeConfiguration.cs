using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class CostTypeConfiguration : IEntityTypeConfiguration<CostType>
{
    internal const string FkCostType = "CostTypeId";
    
    public void Configure(EntityTypeBuilder<CostType> builder)
    {
        builder.HasKey(ct => ct.Id);
        builder.Property(ct => ct.Id).UseIdentityColumn();
        builder.HasMany(ct => ct.Prices).WithOne(p => p.CostType).HasForeignKey(FkCostType);
    }
}