using EFCore.RepositoryPattern.Sample.Data.Entities;
using EFCore.RepositoryPattern.Sample.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.RepositoryPattern.Sample.Data.Configurations
{
    public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasQueryFilter(car => !car.IsDeleted);

            builder
                .HasKey(car => car.Id)
                .HasAnnotation(
                    annotation: "SqlServer:ValueGenerationStrategy",
                    value: SqlServerValueGenerationStrategy.IdentityColumn);

            builder
                .HasIndex(car => car.VinNumber)
                .IsUnique();

            builder
                .Property(car => car.DealerId)
                .IsRequired();

            builder
                .Property(car => car.Manufacturer)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(car => car.Model)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(car => car.Description)
                .HasMaxLength(4001);

            builder
                .Property(car => car.VinNumber)
                .HasMaxLength(17)
                .IsRequired();

            builder
                .Property(car => car.BodyType)
                .HasDefaultValue(BodyType.Unspecified)
                .IsRequired();

            builder
                .Property(car => car.FuelType)
                .HasDefaultValue(FuelType.Other)
                .IsRequired();

            builder
                .Property(car => car.ProductionDate)
                .IsRequired();

            builder
                .Property(car => car.CreatedAt)
                .IsRequired();

            builder
                .Property(car => car.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
