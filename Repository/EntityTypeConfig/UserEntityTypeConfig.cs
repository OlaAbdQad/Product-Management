using Assessment_Task.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment_Task.Repository.EntityTypeConfig
{
    public class UserEntityTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(p => p.RoleName)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("Users");
            builder.HasData(
             new User{Name = "Super Admin", Email =  "superadmin@gmail.com", Password = "P@$$w0rd",  RoleName = "Super-Admin" }
            );
        }

    }
}