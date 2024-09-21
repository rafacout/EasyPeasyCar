using EasyPeasy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPeasy.Infrastructure.Persistence.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Manufacturer>(x => x.Manufacturer)
            .WithMany(m => m.Models)
            .HasForeignKey(f => f.ManufacturerId);
        
        builder.HasOne<Category>(x => x.Category)
            .WithMany(c => c.Models)
            .HasForeignKey(f => f.CategoryId);
        
        builder.HasMany<Vehicle>()
            .WithOne(x => x.Model)
            .HasForeignKey(f => f.ModelId);
    }
}