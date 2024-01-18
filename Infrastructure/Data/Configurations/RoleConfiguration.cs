using Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).HasMaxLength(10);

            builder.HasOne(c => c.RoleTypes)
                .WithMany(c => c.Role)
                .HasForeignKey(c => c.RoleTypeId);
        }
    }
}
