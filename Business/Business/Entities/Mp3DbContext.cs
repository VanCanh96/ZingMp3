using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Mp3DbContext : DbContext
    {
        public Mp3DbContext(DbContextOptions<Mp3DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Vip> Vips { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gender
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(m => m.Id).UseIdentityColumn();
                entity.Property(m => m.Name).HasMaxLength(50).IsRequired();
                entity.Property(m => m.CreateAt).IsRequired();
                entity.Property(m => m.CreateBy).IsRequired();
                entity.Property(m => m.UpdateAt);
                entity.Property(m => m.UpdateBy);
            });

            // Gender
            modelBuilder.Entity<Vip>(entity =>
            {
                entity.Property(m => m.Id).UseIdentityColumn();
                entity.Property(m => m.Name).HasMaxLength(50).IsRequired();
                entity.Property(m => m.CreateAt).IsRequired();
                entity.Property(m => m.CreateBy).IsRequired();
                entity.Property(m => m.UpdateAt);
                entity.Property(m => m.UpdateBy);
            });

            // Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(m => m.Id).UseIdentityColumn();
                entity.Property(m => m.Name).HasMaxLength(50).IsRequired();
                entity.Property(m => m.GenderId).HasMaxLength(1);
                entity.Property(m => m.Address).HasMaxLength(500);
                entity.Property(m => m.DateOfBirth);
                entity.Property(m => m.VipId).HasMaxLength(1);
                entity.Property(m => m.IsActive).HasDefaultValue(false);
                entity.Property(m => m.CreateAt).IsRequired();
                entity.Property(m => m.CreateBy).IsRequired();
                entity.Property(m => m.UpdateAt);
                entity.Property(m => m.UpdateBy);

                entity.HasOne(e => e.Gender)
                    .WithMany(e => e.Accounts)
                    .HasForeignKey(f => f.GenderId)
                    .HasConstraintName("FK_Account_Gender_GenderId");
            });

            modelBuilder.Entity<Gender>().HasData(
                new { Id = 1, Name = "Nam", CreateAt = DateTime.UtcNow, CreateBy = 0 },
                new { Id = 2, Name = "Nữ", CreateAt = DateTime.UtcNow, CreateBy = 0 }
                );

            modelBuilder.Entity<Vip>().HasData(
                new { Id = 1, Name = "Vip 1", CreateAt = DateTime.UtcNow, CreateBy = 0 },
                new { Id = 2, Name = "Vip 2", CreateAt = DateTime.UtcNow, CreateBy = 0 },
                new { Id = 99, Name = "Master", CreateAt = DateTime.UtcNow, CreateBy = 0 }
                );

            modelBuilder.Entity<Account>().HasData(
                new { Id = 1, Name = "Admin", UserName = "admin", Password = "123456", GenderId = 1, DateOfBirth = new DateTime(1996, 12, 22), Address = "Đà Nẵng",
                    VipId = 99, IsActive = true, CreateAt = DateTime.UtcNow, CreateBy = 0 }
                );
        }
    }
}
