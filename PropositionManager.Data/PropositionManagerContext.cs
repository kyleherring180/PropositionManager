using System.ComponentModel;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PropositionManager.Data.Enums;
using PropositionManager.Data.Shared;
using PropositionManager.Model.Entities;
using PropositionManager.Model.Enums;

namespace PropositionManager.Data;

public class PropositionManagerContext : DbContext
{
    public PropositionManagerContext(DbContextOptions<PropositionManagerContext> options) : base(options)
    {
    }

    public PropositionManagerContext(string connectionString) : base(
        new DbContextOptionsBuilder<PropositionManagerContext>().UseSqlServer(connectionString).Options)
    {
    }
    
    public DbSet<Proposition> Propositions { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<PropositionPrice> PropositionPrices { get; set; }
    public DbSet<TariffDuration> TariffDurations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        ApplyGeneralSettings(modelBuilder);
        ApplyEnumData(modelBuilder);
    }

    private static void ApplyGeneralSettings(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private static void ApplyEnumData(ModelBuilder modelBuilder)
    {
        AddEnumData<CurrencyEntity, Currency>(modelBuilder);
        AddEnumData<PriceStatusEntity, PriceStatus>(modelBuilder);
        AddEnumData<ProductTypeEntity, ProductType>(modelBuilder);
        AddEnumData<TariffDurationUnitEntity, TariffDurationUnit>(modelBuilder);
    }

    private static void AddEnumData<TEntity, TEnum>(ModelBuilder modelBuilder, bool skipEnumDefaultValue = true)
        where TEntity : AbstractEnumTable<TEnum>, new()
        where TEnum : System.Enum
    {
        var enumType = typeof(TEnum);
        var enumNames = Enum.GetNames(enumType);
        foreach (var name in enumNames)
        {
            TEnum id = (TEnum)Enum.Parse(enumType, name);

            if (skipEnumDefaultValue && id.Equals(default(TEnum)))
            {
                continue;
            }

            string description = enumType.GetMember(name).Single()
                .GetCustomAttributes(typeof(DebuggableAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description;

            modelBuilder.Entity<TEntity>().HasData(new TEntity { Id = id, Description = description, Name = name });
        }
    }
}