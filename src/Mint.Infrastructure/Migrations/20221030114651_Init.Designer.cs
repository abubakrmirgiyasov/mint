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
    [Migration("20221030114651_Init")]
    partial class Init
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
                            Id = new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"),
                            City = "Новокузнецк",
                            CountryId = new Guid("3ab57d1d-0b9e-4216-a2fd-13a082777047"),
                            Description = "г. Новокузнецк ул. Бардина 23, ком. 302",
                            Home = "302",
                            PostCode = 640000,
                            Street = "Бардина 23"
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

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                            Id = new Guid("611fb824-68b8-43df-a5f3-9d92cd1c79ba"),
                            AddressId = new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"),
                            ConfirmedPassword = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Email = "abubakrmirgiyasov@gmail.com",
                            FirstName = "Миргиясов",
                            LastName = "Мукимжонович",
                            Password = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Phone = 89502768428L,
                            SecondName = "Абубакр"
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
                            Id = new Guid("914db199-c42c-43ac-bfef-de993eb83cfb"),
                            CategoryId = new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"),
                            Name = "Apple Iphone"
                        },
                        new
                        {
                            Id = new Guid("4bdf8769-75fa-4bb9-b638-203dadd504f9"),
                            CategoryId = new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"),
                            Name = "Xiaomi"
                        },
                        new
                        {
                            Id = new Guid("826b6dfd-69fc-44b9-8c0b-3b0905ad37d5"),
                            CategoryId = new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"),
                            Name = "Экшн-камеры"
                        },
                        new
                        {
                            Id = new Guid("593e90aa-71e1-4872-8e38-4006cebe72c9"),
                            CategoryId = new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"),
                            Name = "Умные брелоки"
                        },
                        new
                        {
                            Id = new Guid("682b968f-f38d-494d-86da-eb3406d020ac"),
                            CategoryId = new Guid("f0d9ff98-04d8-483c-bf5e-3b15b5cf2037"),
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
                            Id = new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"),
                            Name = "Смартфоны"
                        },
                        new
                        {
                            Id = new Guid("f0d9ff98-04d8-483c-bf5e-3b15b5cf2037"),
                            Name = "Аксессуары"
                        },
                        new
                        {
                            Id = new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"),
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
                            Id = new Guid("3ab57d1d-0b9e-4216-a2fd-13a082777047"),
                            Name = "Россия"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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
                            Id = new Guid("695b4d9d-cc94-4826-be91-fc3b1fd10f11"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("e2147fb1-0a85-4a16-b90c-9bf9c42c83dc"),
                            Name = "Buyer"
                        },
                        new
                        {
                            Id = new Guid("6f52e195-1f17-4827-88dd-f93e07867819"),
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
                            Id = new Guid("1ea7a394-fdb0-4b4d-8a6c-5070b7be78ae"),
                            AddressId = new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"),
                            ConfirmedPassword = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            CreatedDate = new DateTime(2022, 10, 30, 18, 46, 51, 541, DateTimeKind.Local).AddTicks(7889),
                            Email = "abubakrmirgiyasov@gmail.com",
                            FirstName = "Миргиясов",
                            Ip = "127.0.0.1",
                            IsActiveAccount = true,
                            LastName = "Мукимжонович",
                            NumOfAttempts = 0,
                            Password = "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN",
                            Phone = 89502768428L,
                            RoleId = new Guid("695b4d9d-cc94-4826-be91-fc3b1fd10f11"),
                            SecondName = "Абубакр"
                        },
                        new
                        {
                            Id = new Guid("213e788c-5f27-4669-96ee-e95a30e9105f"),
                            AddressId = new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"),
                            ConfirmedPassword = "dGVzdF8x",
                            CreatedDate = new DateTime(2022, 10, 30, 18, 46, 51, 541, DateTimeKind.Local).AddTicks(7929),
                            Email = "test@gmail.com",
                            FirstName = "Test",
                            Ip = "127.0.0.2",
                            IsActiveAccount = true,
                            NumOfAttempts = 0,
                            Password = "dGVzdF8x",
                            Phone = 89502768529L,
                            RoleId = new Guid("e2147fb1-0a85-4a16-b90c-9bf9c42c83dc"),
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
                    b.HasOne("Mint.Domain.Models.Brand", "Brand")
                        .WithMany("Photos")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Mint.Domain.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

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