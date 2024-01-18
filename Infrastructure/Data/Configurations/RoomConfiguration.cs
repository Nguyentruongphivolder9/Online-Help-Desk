using Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(r => r.RoomNumber).HasMaxLength(10);
            builder.Property(r => r.RoomStatus).HasMaxLength(20);

            builder.HasOne(r => r.Departments)
                .WithMany(d => d.Rooms)
                .HasForeignKey(r => r.DepartmentId);
        }
    }
}
