using Assessment_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment_Task.Repository.EntityTypeConfig
{
    public class ProductEntityTypeConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.IsDisabled)
                .HasDefaultValue(false);

            builder.ToTable("Products");
        }

        
    }
}