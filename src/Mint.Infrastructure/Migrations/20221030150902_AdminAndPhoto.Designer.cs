﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mint.Infrastructure;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221030150902_AdminAndPhoto")]
    partial class AdminAndPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mint.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Home")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"),
                            City = "Новокузнецк",
                            CountryId = new Guid("3f163607-5132-42cc-9d76-f781423dcd81"),
                            Description = "г. Новокузнецк ул. Бардина 23, ком. 302",
                            Home = "302",
                            PostCode = 640000,
                            Street = "Бардина 23"
                        },
                        new
                        {
                            Id = new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"),
                            City = "Test",
                            CountryId = new Guid("3f163607-5132-42cc-9d76-f781423dcd81"),
                            Description = "г. Test Street, ком. 302",
                            Home = "302",
                            PostCode = 123456,
                            Street = "Street"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumOfAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31d81c07-c4d7-439e-b87e-df1c5f8e5dec"),
                            AddressId = new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"),
                            ConfirmedPassword = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Email = "abubakrmirgiyasov@gmail.com",
                            FirstName = "Миргиясов",
                            IsActive = true,
                            LastName = "Мукимжонович",
                            NumOfAttempts = 0,
                            Password = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Phone = 89502768428L,
                            SecondName = "Абубакр"
                        },
                        new
                        {
                            Id = new Guid("8bce750b-3d3f-46a1-bd3e-10781d4bc20c"),
                            AddressId = new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"),
                            ConfirmedPassword = "dGVzdF8x",
                            Email = "test@gmail.com",
                            FirstName = "Test",
                            IsActive = true,
                            NumOfAttempts = 0,
                            Password = "dGVzdF8x",
                            Phone = 89502768529L,
                            SecondName = "User"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8742acfc-c03f-4e51-8427-df895c901b6d"),
                            CategoryId = new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"),
                            Name = "Apple Iphone"
                        },
                        new
                        {
                            Id = new Guid("133ec355-adc1-4cf3-82b1-dc4e5e795c46"),
                            CategoryId = new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"),
                            Name = "Xiaomi"
                        },
                        new
                        {
                            Id = new Guid("72467801-1688-4223-8309-1a3ee8977d4f"),
                            CategoryId = new Guid("e39534b6-8d29-4e72-b19e-a979719763af"),
                            Name = "Экшн-камеры"
                        },
                        new
                        {
                            Id = new Guid("30a4eea0-9ff8-4eae-96d9-f9596cf8abe9"),
                            CategoryId = new Guid("e39534b6-8d29-4e72-b19e-a979719763af"),
                            Name = "Умные брелоки"
                        },
                        new
                        {
                            Id = new Guid("53f6d744-e2e4-4ba3-b082-b2e69c5ae695"),
                            CategoryId = new Guid("7e42480a-e0bc-46bb-9391-2e7dae90ec60"),
                            Name = "Смарт часы"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"),
                            Name = "Смартфоны"
                        },
                        new
                        {
                            Id = new Guid("7e42480a-e0bc-46bb-9391-2e7dae90ec60"),
                            Name = "Аксессуары"
                        },
                        new
                        {
                            Id = new Guid("e39534b6-8d29-4e72-b19e-a979719763af"),
                            Name = "Гаджеты"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f163607-5132-42cc-9d76-f781423dcd81"),
                            Name = "Россия"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("FileBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FileSize")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("BrandId");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Mint.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eda63245-1f16-4f26-a74d-0a538b640e34"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("ade0a62e-9596-42bd-ac12-2c388035938f"),
                            Name = "Buyer"
                        },
                        new
                        {
                            Id = new Guid("25f10de6-c2d6-4fa6-a971-dc66cbe49029"),
                            Name = "Deliver"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActiveAccount")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("NumOfAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d42bb87-7150-4e6c-a14b-eeffd3ba62b2"),
                            AddressId = new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"),
                            ConfirmedPassword = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            CreatedDate = new DateTime(2022, 10, 30, 22, 9, 1, 910, DateTimeKind.Local).AddTicks(5984),
                            Email = "abubakrmirgiyasov@gmail.com",
                            FirstName = "Миргиясов",
                            Ip = "127.0.0.1",
                            IsActiveAccount = true,
                            LastName = "Мукимжонович",
                            NumOfAttempts = 0,
                            Password = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Phone = 89502768428L,
                            RoleId = new Guid("eda63245-1f16-4f26-a74d-0a538b640e34"),
                            SecondName = "Абубакр"
                        },
                        new
                        {
                            Id = new Guid("e2b72330-582c-4fa0-b62f-8f3e64be49b6"),
                            AddressId = new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"),
                            ConfirmedPassword = "dGVzdF8x",
                            CreatedDate = new DateTime(2022, 10, 30, 22, 9, 1, 910, DateTimeKind.Local).AddTicks(6024),
                            Email = "test@gmail.com",
                            FirstName = "Test",
                            Ip = "127.0.0.1",
                            IsActiveAccount = true,
                            NumOfAttempts = 0,
                            Password = "dGVzdF8x",
                            Phone = 89502768529L,
                            RoleId = new Guid("ade0a62e-9596-42bd-ac12-2c388035938f"),
                            SecondName = "User"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Address", b =>
                {
                    b.HasOne("Mint.Domain.Models.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Mint.Domain.Models.Admin", b =>
                {
                    b.HasOne("Mint.Domain.Models.Address", "Address")
                        .WithMany("Admins")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Mint.Domain.Models.Brand", b =>
                {
                    b.HasOne("Mint.Domain.Models.Category", "Category")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.HasOne("Mint.Domain.Models.Admin", "Admin")
                        .WithMany("Photos")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Mint.Domain.Models.Brand", "Brand")
                        .WithMany("Photos")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Mint.Domain.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Admin");

                    b.Navigation("Brand");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.HasOne("Mint.Domain.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mint.Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Address");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Mint.Domain.Models.Address", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.Admin", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Mint.Domain.Models.Brand", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Mint.Domain.Models.Category", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("Mint.Domain.Models.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Mint.Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}