﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(OHDDbContext))]
    partial class OHDDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Accounts.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AvatarPhoto")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("StatusAccount")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerifyCode")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime?>("VerifyRefreshExpiry")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = "ST729729",
                            Address = "Bình Chánh",
                            Birthday = "1975/04/30",
                            CreatedAt = new DateTime(2024, 2, 26, 21, 20, 8, 743, DateTimeKind.Local).AddTicks(4773),
                            Email = "student@gmail.com",
                            Enable = true,
                            FullName = "Duy Hiển",
                            Gender = "Male",
                            Password = "$2a$12$GPbRVLdOyRw7H1yw/.fv/uStTWDcvprTAergcVbhc7zQ3/zFAqOtW",
                            PhoneNumber = "0909009001",
                            RoleId = 1,
                            StatusAccount = "Active"
                        },
                        new
                        {
                            AccountId = "TC729729",
                            Address = "Bình Dương",
                            Birthday = "1945/09/02",
                            CreatedAt = new DateTime(2024, 2, 26, 21, 20, 8, 743, DateTimeKind.Local).AddTicks(4787),
                            Email = "teacher@gmail.com",
                            Enable = true,
                            FullName = "Duy Hiển",
                            Gender = "Female",
                            Password = "$2a$12$GPbRVLdOyRw7H1yw/.fv/uStTWDcvprTAergcVbhc7zQ3/zFAqOtW",
                            PhoneNumber = "0909009002",
                            RoleId = 2,
                            StatusAccount = "Verifying"
                        },
                        new
                        {
                            AccountId = "AS729729",
                            Address = "Bình Định",
                            Birthday = "1954/06/07",
                            CreatedAt = new DateTime(2024, 2, 26, 21, 20, 8, 743, DateTimeKind.Local).AddTicks(4789),
                            Email = "assignees@gmail.com",
                            Enable = true,
                            FullName = "Johnny Đãng",
                            Gender = "Orther",
                            Password = "$2a$12$GPbRVLdOyRw7H1yw/.fv/uStTWDcvprTAergcVbhc7zQ3/zFAqOtW",
                            PhoneNumber = "0909009003",
                            RoleId = 4,
                            StatusAccount = "Active"
                        },
                        new
                        {
                            AccountId = "FH729729",
                            Address = "Alaska",
                            Birthday = "1975/04/30",
                            CreatedAt = new DateTime(2024, 2, 26, 21, 20, 8, 743, DateTimeKind.Local).AddTicks(4791),
                            Email = "facility@gmail.com",
                            Enable = true,
                            FullName = "Ngọc Nhi",
                            Gender = "Orther",
                            Password = "$2a$12$GPbRVLdOyRw7H1yw/.fv/uStTWDcvprTAergcVbhc7zQ3/zFAqOtW",
                            PhoneNumber = "0909009004",
                            RoleId = 3,
                            StatusAccount = "Active"
                        },
                        new
                        {
                            AccountId = "AD729729",
                            Address = "Alaska",
                            Birthday = "1975/04/30",
                            CreatedAt = new DateTime(2024, 2, 26, 21, 20, 8, 743, DateTimeKind.Local).AddTicks(4792),
                            Email = "nguyentruongphi15032003@gmail.com",
                            Enable = true,
                            FullName = "Phi Đzai",
                            Gender = "Orther",
                            Password = "$2a$12$GPbRVLdOyRw7H1yw/.fv/uStTWDcvprTAergcVbhc7zQ3/zFAqOtW",
                            PhoneNumber = "0937888707",
                            RoleId = 5,
                            StatusAccount = "Active"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Departments.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RoomStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.HelpAbout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HelpAbouts");
                });

            modelBuilder.Entity("Domain.Entities.Requests.NotificationHandleRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RequestId");

                    b.ToTable("NotificationHandleRequest");
                });

            modelBuilder.Entity("Domain.Entities.Requests.NotificationRemark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Unwatchs")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RequestId");

                    b.ToTable("NotificationRemark");
                });

            modelBuilder.Entity("Domain.Entities.Requests.ProcessByAssignees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RequestId");

                    b.ToTable("ProcessByAssignees");
                });

            modelBuilder.Entity("Domain.Entities.Requests.Remark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RequestId");

                    b.ToTable("Remarks");
                });

            modelBuilder.Entity("Domain.Entities.Requests.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeveralLevel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RequestStatusId");

                    b.HasIndex("RoomId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Domain.Entities.Requests.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("RequestStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorCode = "#3300FF",
                            StatusName = "Open"
                        },
                        new
                        {
                            Id = 2,
                            ColorCode = "#FFFF00",
                            StatusName = "Assigned"
                        },
                        new
                        {
                            Id = 3,
                            ColorCode = "#FF6600",
                            StatusName = "Work in progress"
                        },
                        new
                        {
                            Id = 4,
                            ColorCode = "#FF0033",
                            StatusName = "Need more info"
                        },
                        new
                        {
                            Id = 5,
                            ColorCode = "#FF0000",
                            StatusName = "Rejected"
                        },
                        new
                        {
                            Id = 6,
                            ColorCode = "#33FF33",
                            StatusName = "Completed"
                        },
                        new
                        {
                            Id = 7,
                            ColorCode = "#FF0000",
                            StatusName = "Closed"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleTypeId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Student",
                            RoleTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Teacher",
                            RoleTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Request Handler",
                            RoleTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            RoleName = "Assignees",
                            RoleTypeId = 3
                        },
                        new
                        {
                            Id = 5,
                            RoleName = "Admin",
                            RoleTypeId = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.Roles.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleTypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("RoleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleTypeName = "End-Users"
                        },
                        new
                        {
                            Id = 2,
                            RoleTypeName = "Facility-Heads"
                        },
                        new
                        {
                            Id = 3,
                            RoleTypeName = "Assignees"
                        },
                        new
                        {
                            Id = 4,
                            RoleTypeName = "Administrator"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Accounts.Account", b =>
                {
                    b.HasOne("Domain.Entities.Roles.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Room", b =>
                {
                    b.HasOne("Domain.Entities.Departments.Department", "Departments")
                        .WithMany("Rooms")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Domain.Entities.Requests.NotificationHandleRequest", b =>
                {
                    b.HasOne("Domain.Entities.Accounts.Account", "Account")
                        .WithMany("NotificationHandleRequests")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Requests.Request", "Request")
                        .WithMany("NotificationHandleRequests")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Entities.Requests.NotificationRemark", b =>
                {
                    b.HasOne("Domain.Entities.Accounts.Account", "Account")
                        .WithMany("NotificationRemarks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Requests.Request", "Request")
                        .WithMany("NotificationRemarks")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Entities.Requests.ProcessByAssignees", b =>
                {
                    b.HasOne("Domain.Entities.Accounts.Account", "Account")
                        .WithMany("ProcessByAssignees")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Requests.Request", "Request")
                        .WithMany("ProcessByAssignees")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Entities.Requests.Remark", b =>
                {
                    b.HasOne("Domain.Entities.Accounts.Account", "Account")
                        .WithMany("Remarks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Requests.Request", "Request")
                        .WithMany("Remarks")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Entities.Requests.Request", b =>
                {
                    b.HasOne("Domain.Entities.Accounts.Account", "Account")
                        .WithMany("Requests")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Requests.RequestStatus", "RequestStatus")
                        .WithMany("Requests")
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Departments.Room", "Room")
                        .WithMany("Requests")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("RequestStatus");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Domain.Entities.Roles.Role", b =>
                {
                    b.HasOne("Domain.Entities.Roles.RoleType", "RoleTypes")
                        .WithMany("Role")
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleTypes");
                });

            modelBuilder.Entity("Domain.Entities.Accounts.Account", b =>
                {
                    b.Navigation("NotificationHandleRequests");

                    b.Navigation("NotificationRemarks");

                    b.Navigation("ProcessByAssignees");

                    b.Navigation("Remarks");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Department", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Room", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.Requests.Request", b =>
                {
                    b.Navigation("NotificationHandleRequests");

                    b.Navigation("NotificationRemarks");

                    b.Navigation("ProcessByAssignees");

                    b.Navigation("Remarks");
                });

            modelBuilder.Entity("Domain.Entities.Requests.RequestStatus", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.Roles.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Domain.Entities.Roles.RoleType", b =>
                {
                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
