using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class HelpAboutConfiguration : IEntityTypeConfiguration<HelpAbout>
    {
        public void Configure(EntityTypeBuilder<HelpAbout> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(h => h.Title).HasMaxLength(200);
        }
    }
}
