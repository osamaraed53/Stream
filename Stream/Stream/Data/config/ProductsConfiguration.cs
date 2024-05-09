using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;
using System.Reflection.Emit;

namespace Stream.Data.config;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
       .HasKey(x => x.ProductId);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId).IsRequired(false);

        builder.Property(x => x.Price).HasColumnType("DECIMAL(8,2)").HasDefaultValue(0);
        builder.Property(x => x.Qty).HasColumnType("INT(10)").HasDefaultValue(0);
        builder.Property(x => x.ProductDescription).HasColumnType("VARCHAR").HasMaxLength(1024);
        builder.Property(x => x.Color).HasColumnType("VARCHAR").HasMaxLength(64);
        builder.Property(x => x.Size).HasColumnType("VARCHAR").HasMaxLength(8);

    }
}
