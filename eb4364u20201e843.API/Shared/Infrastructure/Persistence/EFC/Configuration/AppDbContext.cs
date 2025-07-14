using eb4364u20201e843.API.MRP.Domain.Model.Aggregates;
using eb4364u20201e843.API.SCM.Domain.Model.Aggregates;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // SCM Context Configuration
        builder.Entity<Part>().HasKey(p => p.Id);
        builder.Entity<Part>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Part>().OwnsOne(p => p.PartNumber,
            pn =>
            {
                pn.WithOwner().HasForeignKey("Id");
                pn.Property(p => p.Identifier).HasColumnName("PartNumber").IsRequired();
            });
        builder.Entity<Part>().Property(p => p.Name).IsRequired().HasMaxLength(60);
        builder.Entity<Part>().HasIndex(p => p.Name).IsUnique();
        builder.Entity<Part>().Property(p => p.PartType).IsRequired();
        builder.Entity<Part>().Property(p => p.CurrentProductionQuantity).IsRequired();
        builder.Entity<Part>().Property(p => p.MaxProductionCapacity).IsRequired();

        // MRP Context Configuration
        builder.Entity<BillOfMaterialsItem>().HasKey(b => b.Id);
        builder.Entity<BillOfMaterialsItem>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BillOfMaterialsItem>().Property(b => b.BillOfMaterialsId).IsRequired();
        builder.Entity<BillOfMaterialsItem>().OwnsOne(b => b.ItemPartNumber,
            ipn =>
            {
                ipn.WithOwner().HasForeignKey("Id");
                ipn.Property(pn => pn.Identifier).HasColumnName("ItemPartNumber").IsRequired();
            });
        builder.Entity<BillOfMaterialsItem>().Property(b => b.BatchId).IsRequired();
        builder.Entity<BillOfMaterialsItem>().Property(b => b.RequiredQuantity).IsRequired();
        builder.Entity<BillOfMaterialsItem>().Property(b => b.ScheduledStartAt).IsRequired();
        builder.Entity<BillOfMaterialsItem>().Property(b => b.RequiredAt).IsRequired();

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}