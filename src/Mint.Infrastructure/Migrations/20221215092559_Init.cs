using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Home = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfAttempts = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IsActiveAccount = table.Column<bool>(type: "bit", nullable: false),
                    NumOfAttempts = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConfirmedPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("478b218c-6ceb-4a32-a745-f3d396dba216"), "Смартфоны" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("74716b77-27c7-4931-9b10-d5952e1c7e39"), "Россия" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a93076fe-d364-472f-8146-2abd15e980c8"), "Buyer" },
                    { new Guid("bcf66b8c-3692-48ad-9729-4f88ea59e43d"), "Admin" },
                    { new Guid("e1a1ad98-a384-477e-bed5-45280591f624"), "Deliver" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "Home", "PostCode", "Street" },
                values: new object[,]
                {
                    { new Guid("6c914d98-996d-469d-b036-239c390f9181"), "Новокузнецк", new Guid("74716b77-27c7-4931-9b10-d5952e1c7e39"), "г. Новокузнецк ул. Бардина 23, ком. 302", "302", 640000, "Бардина 23" },
                    { new Guid("9b708e84-a2f4-4d7b-a5ef-c3b766ac4d45"), "Test", new Guid("74716b77-27c7-4931-9b10-d5952e1c7e39"), "г. Test Street, ком. 302", "302", 123456, "Street" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { new Guid("e7a71dd1-44ca-401f-bf9b-3adadcaa81d4"), new Guid("478b218c-6ceb-4a32-a745-f3d396dba216"), "Samsung" });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { new Guid("a8097bc6-b167-4fcc-8128-c7aeee884f1b"), new Guid("478b218c-6ceb-4a32-a745-f3d396dba216"), "Samsung Galaxy" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "Email", "FirstName", "IsActive", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("68db30fe-e377-4d4b-88d0-2a6cc84eb690"), new Guid("9b708e84-a2f4-4d7b-a5ef-c3b766ac4d45"), "dGVzdF8x", "test@gmail.com", "Test", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("bcf66b8c-3692-48ad-9729-4f88ea59e43d"), "User" },
                    { new Guid("7e05be4a-3e34-4a51-a0e0-eb2dce1d9dd7"), new Guid("6c914d98-996d-469d-b036-239c390f9181"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("bcf66b8c-3692-48ad-9729-4f88ea59e43d"), "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("2cac7cd2-6a1c-4e58-81fc-5c4272094633"), new Guid("6c914d98-996d-469d-b036-239c390f9181"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 12, 15, 16, 25, 59, 235, DateTimeKind.Local).AddTicks(6786), "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("bcf66b8c-3692-48ad-9729-4f88ea59e43d"), "Абубакр" },
                    { new Guid("684dc365-f4ac-4afc-b053-532865669377"), new Guid("6c914d98-996d-469d-b036-239c390f9181"), "dGVzdF8x", new DateTime(2022, 12, 15, 16, 25, 59, 235, DateTimeKind.Local).AddTicks(6844), "test@gmail.com", "Test", "127.0.0.1", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("bcf66b8c-3692-48ad-9729-4f88ea59e43d"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AddressId",
                table: "Admins",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Phone",
                table: "Admins",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdminId",
                table: "Photos",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BrandId",
                table: "Photos",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_SubCategoryId",
                table: "Photos",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
