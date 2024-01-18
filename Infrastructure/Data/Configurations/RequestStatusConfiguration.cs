using Domain.Entities.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
    {

        public void Configure(EntityTypeBuilder<RequestStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(rs => rs.StatusName).HasMaxLength(20);
            builder.Property(rs => rs.ColorCode).HasMaxLength(10);
        }
    }
}
