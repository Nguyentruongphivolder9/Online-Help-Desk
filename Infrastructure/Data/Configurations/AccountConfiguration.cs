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
            builder.Property(acc => acc.FullName).HasMaxLength(30);
            builder.Property(acc => acc.Email).HasMaxLength(200);
            builder.Property(acc => acc.AvatarPhoto).HasMaxLength(255);
            builder.Property(acc => acc.Address).HasMaxLength(200);
            builder.Property(acc => acc.PhoneNumber).HasMaxLength(11);
            builder.Property(acc => acc.Gender).HasMaxLength(20);
            builder.Property(acc => acc.Birthday).HasMaxLength(15);
            builder.Property(acc => acc.VerifyCode).HasMaxLength(7);
            builder.Property(acc => acc.RefreshToken).HasMaxLength(255);
            builder.Property(acc => acc.StatusAccount).HasMaxLength(20);

            builder.HasOne(acc => acc.Role)
                .WithMany(role => role.Accounts)
                .HasForeignKey(acc => acc.RoleId);

            builder.HasData(new Account[]
            {
                new Account { AccountId = "ST729729", RoleId = 1, Password = "@abcOHD123", FullName = "Johnny Depp", 
                    Email = "student@gmail.com", Address = "Bình Chánh", PhoneNumber = "0909009009", Gender = "Male", 
                    Birthday = "30/04/1975", StatusAccount = "Active", Enable = true, CreatedAt = DateTime.UtcNow },
                new Account { AccountId = "TC729729", RoleId = 2, Password = "@abcOHD123", FullName = "Johnny Dark", 
                    Email = "teacher@gmail.com", Address = "Bình Dương", PhoneNumber = "0909009009", Gender = "Female", 
                    Birthday = "02/09/1945", StatusAccount = "Verifying", Enable = true, CreatedAt = DateTime.UtcNow },
                new Account { AccountId = "AS729729", RoleId = 3, Password = "@abcOHD123", FullName = "Johnny Đãng", 
                    Email = "assignees@gmail.com", Address = "Bình Định", PhoneNumber = "0909009009", Gender = "Orther", 
                    Birthday = "07/05/1954", StatusAccount = "Active", Enable = true, CreatedAt = DateTime.UtcNow },
                new Account { AccountId = "FH729729", RoleId = 4, Password = "@abcOHD123", FullName = "Johnny Bruno", 
                    Email = "facility@gmail.com", Address = "Alaska", PhoneNumber = "0909009009", Gender = "Orther", 
                    Birthday = "30/04/1945", StatusAccount = "Active", Enable = true, CreatedAt = DateTime.UtcNow },
                new Account { AccountId = "AD729729", RoleId = 5, Password = "@Phi729729", FullName = "Johnny Đặng", 
                    Email = "nguyentruongphi15032003@gmail.com", Address = "Alaska", PhoneNumber = "0937888707", Gender = "Orther", 
                    Birthday = "30/04/1945", StatusAccount = "Active", Enable = true, CreatedAt = DateTime.UtcNow },
            });
        }
    }
}
