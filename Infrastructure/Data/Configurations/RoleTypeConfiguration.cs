using Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
    {
        public void Configure(EntityTypeBuilder<RoleType> builder)
        {
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.RoleTypeName);
        }
    }
}
