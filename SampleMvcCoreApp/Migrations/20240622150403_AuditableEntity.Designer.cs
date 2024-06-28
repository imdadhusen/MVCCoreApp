﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleMvcCoreApp.Entities;

#nullable disable

namespace SampleMvcCoreApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240622150403_AuditableEntity")]
    partial class AuditableEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressDetail = "Ahmedabad",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5804),
                            EmployeeId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AddressDetail = "Surat",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5807),
                            EmployeeId = 1,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AddressDetail = "Patan",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5808),
                            EmployeeId = 2,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AddressDetail = "Siddhpur",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5810),
                            EmployeeId = 3,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            AddressDetail = "Palanpur",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5812),
                            EmployeeId = 4,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            AddressDetail = "Ahmedabad",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5813),
                            EmployeeId = 5,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DepartmentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5836),
                            DepartmentName = "Development",
                            DepartmentPhone = "9909544184",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5838),
                            DepartmentName = "Testing",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5840),
                            DepartmentName = "Human Resource",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5841),
                            DepartmentName = "Finance",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5843),
                            DepartmentName = "Marketing",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5844),
                            DepartmentName = "Admin",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5626),
                            DepartmentId = 1,
                            Email = "Test@test.com",
                            EmployeeName = "Test Emp1",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Test1",
                            Skill = "Test1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5629),
                            DepartmentId = 2,
                            Email = "Test2@test.com",
                            EmployeeName = "Test Emp2",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Test2",
                            Skill = "Test2"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5632),
                            DepartmentId = 3,
                            Email = "Test3@test.com",
                            EmployeeName = "Test Emp3",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Test3",
                            Skill = "Test3"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5634),
                            DepartmentId = 4,
                            Email = "SoftDelete@test.com",
                            EmployeeName = "Soft Deleted Employee",
                            IsActive = true,
                            IsDeleted = true,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Deleted",
                            Skill = "Soft Delete"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 6, 22, 15, 4, 1, 424, DateTimeKind.Utc).AddTicks(5635),
                            DepartmentId = 4,
                            Email = "Inactive@test.com",
                            EmployeeName = "Inactive Employee",
                            IsActive = false,
                            IsDeleted = false,
                            ModifiedBy = 0,
                            ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Inactive",
                            Skill = "In Active"
                        });
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Address", b =>
                {
                    b.HasOne("SampleMvcCoreApp.Entities.Employee", "Employee")
                        .WithMany("EmployeeAddress")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Employee", b =>
                {
                    b.HasOne("SampleMvcCoreApp.Entities.Department", "Department")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Department", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SampleMvcCoreApp.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeAddress");
                });
#pragma warning restore 612, 618
        }
    }
}