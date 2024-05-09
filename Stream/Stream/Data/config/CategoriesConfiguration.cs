using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stream.Models;

namespace Stream.Data.config;

public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.CategoryId);
        builder.Property(x => x.CategoryName).HasColumnType("VARCHAR").HasMaxLength(64);
        builder.Property(x => x.CategoryDescription).HasColumnType("VARCHAR").HasMaxLength(1024);

        builder.HasData(new Category { CategoryId = 1, CategoryName = "not have Category", CategoryDescription = "Change is recommended" }); ;
    }

}
