﻿// <auto-generated />
using System;
using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Business.Migrations
{
    [DbContext(typeof(Mp3DbContext))]
    partial class Mp3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Business.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("CreateAt")
                        .IsRequired();

                    b.Property<int>("CreateBy");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<int>("GenderId")
                        .HasMaxLength(1);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<int?>("UpdateBy");

                    b.Property<string>("UserName");

                    b.Property<int>("VipId")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("VipId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new { Id = 1, Address = "Đà Nẵng", CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, DateOfBirth = new DateTime(1996, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), GenderId = 1, IsActive = true, Name = "Admin", VipId = 99 }
                    );
                });

            modelBuilder.Entity("Business.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateAt")
                        .IsRequired();

                    b.Property<int>("CreateBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<int?>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new { Id = 1, CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, Name = "Nam" },
                        new { Id = 2, CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, Name = "Nữ" }
                    );
                });

            modelBuilder.Entity("Business.Entities.Vip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateAt")
                        .IsRequired();

                    b.Property<int>("CreateBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateAt");

                    b.Property<int?>("UpdateBy");

                    b.HasKey("Id");

                    b.ToTable("Vips");

                    b.HasData(
                        new { Id = 1, CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, Name = "Vip 1" },
                        new { Id = 2, CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, Name = "Vip 2" },
                        new { Id = 99, CreateAt = new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), CreateBy = 0, Name = "Master" }
                    );
                });

            modelBuilder.Entity("Business.Entities.Account", b =>
                {
                    b.HasOne("Business.Entities.Gender", "Gender")
                        .WithMany("Accounts")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Account_Gender_GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Business.Entities.Vip")
                        .WithMany("Accounts")
                        .HasForeignKey("VipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
