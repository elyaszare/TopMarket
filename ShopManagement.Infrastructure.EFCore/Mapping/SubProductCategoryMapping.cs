using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SubProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SubProductCategoryMapping : IEntityTypeConfiguration<SubProductCategory>
    {
        public void Configure(EntityTypeBuilder<SubProductCategory> builder)
        {
            builder.ToTable("SubProductCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder
                .HasOne(x => x.ProductCategory)
                .WithMany(x => x.SubProductCategories)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.SubCategory)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
