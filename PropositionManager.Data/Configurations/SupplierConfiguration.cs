using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropositionManager.Data.Extensions;
using PropositionManager.Model.Entities;

namespace PropositionManager.Data.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    internal const string FkSupplier = "SupplierId";
    
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).UseIdentityColumn();
        builder.HasMany(s => s.Propositions).WithOne(p => p.Supplier).HasForeignKey(FkSupplier);
        builder.HasMany(s => s.Prices).WithOne(p => p.Supplier).HasForeignKey(FkSupplier);
        builder.ConfigureVersionConcurrency();
    }
}