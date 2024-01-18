using Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(acc => acc.AccountId);
            builder.Property(acc => acc.FullName).HasMaxLength(20);
            builder.Property(acc => acc.Email).HasMaxLength(100);
            builder.Property(acc => acc.AvatarPhoto).HasMaxLength(255);
            builder.Property(acc => acc.Address).HasMaxLength(100);
            builder.Property(acc => acc.PhoneNumber).HasMaxLength(11);
            builder.Property(acc => acc.Gender).HasMaxLength(20);
            builder.Property(acc => acc.Birthday).HasMaxLength(15);
            builder.Property(acc => acc.VerifyCode).HasMaxLength(7);
            builder.Property(acc => acc.RefreshToken).HasMaxLength(255);
            builder.Property(acc => acc.StatusAccount).HasMaxLength(20);

            builder.HasOne(acc => acc.Role)
                .WithMany(role => role.Accounts)
                .HasForeignKey(acc => acc.RoleId);
        }
    }
}
