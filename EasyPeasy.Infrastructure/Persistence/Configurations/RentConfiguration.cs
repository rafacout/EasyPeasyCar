using EasyPeasy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPeasy.Infrastructure.Persistence.Configurations;

public class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne<Store>()
            .WithMany()
            .HasForeignKey(x => x.StorePickUpId);
        
        builder.HasOne<Store>()
            .WithMany()
            .HasForeignKey(x => x.StoreDropOffId);

        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(x => x.VehicleId);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(x => x.CategoryId);
    }
}