using DL.CategorySystem.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.CategorySystem.Persistence.EFCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Slug)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Ordinal)
                .IsRequired();

            // Relationship
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Childen)
                .HasForeignKey(x => x.ParentCategoryId);

            builder.ToTable("Category");
        }
    }
}
