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
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("251435e6-e24a-4871-ac83-c59b2f5a6903"), "Samsung" },
                    { new Guid("40915553-d89b-4701-9f95-c0babc4e4660"), "Apple" },
                    { new Guid("7b6d1176-ddf2-4fc3-95ea-b5e3265650d9"), "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("28d2c9ef-5088-4a9c-b5a4-ab7d58283b19"), "Россия" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c0256e11-9014-4dae-a582-be799f9e6934"), "Deliver" },
                    { new Guid("e134f2b0-c5b6-4c7e-82c5-6a6fc033d62e"), "Admin" },
                    { new Guid("f234d2d2-5d12-457d-9082-1e92cb1d3de6"), "Buyer" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "Home", "PostCode", "Street" },
                values: new object[,]
                {
                    { new Guid("0fed4fb4-a0ab-4d42-88a6-6705c5b3213a"), "Test", new Guid("28d2c9ef-5088-4a9c-b5a4-ab7d58283b19"), "г. Test Street, ком. 302", "302", 123456, "Street" },
                    { new Guid("f78716a2-6240-495c-b0a0-41e2b322d208"), "Новокузнецк", new Guid("28d2c9ef-5088-4a9c-b5a4-ab7d58283b19"), "г. Новокузнецк ул. Бардина 23, ком. 302", "302", 640000, "Бардина 23" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("0c89933d-6bfa-4822-a852-0663a3350fff"), new Guid("40915553-d89b-4701-9f95-c0babc4e4660"), "Гаджеты" },
                    { new Guid("65948de5-991c-4ee8-8a88-d84a24d7618f"), new Guid("251435e6-e24a-4871-ac83-c59b2f5a6903"), "Экшн-камеры" },
                    { new Guid("8211b092-d498-4877-942e-5b30a83d1c72"), new Guid("251435e6-e24a-4871-ac83-c59b2f5a6903"), "Смарт часы" },
                    { new Guid("84cb92ef-2f4b-4f81-a443-09de001ad984"), new Guid("7b6d1176-ddf2-4fc3-95ea-b5e3265650d9"), "Аксессуары" },
                    { new Guid("b4f269e4-07c2-422b-b358-b16492505f73"), new Guid("40915553-d89b-4701-9f95-c0babc4e4660"), "Смартфоны" },
                    { new Guid("f239bd6b-fc84-4bc7-ab5e-ea67c9398d31"), new Guid("251435e6-e24a-4871-ac83-c59b2f5a6903"), "Умные брелоки" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "Email", "FirstName", "IsActive", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("7d5686c7-cad7-4b72-9d03-9808be3c8572"), new Guid("f78716a2-6240-495c-b0a0-41e2b322d208"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("e134f2b0-c5b6-4c7e-82c5-6a6fc033d62e"), "Абубакр" },
                    { new Guid("8666de54-7327-4bfc-a86a-357ac1c16fdf"), new Guid("0fed4fb4-a0ab-4d42-88a6-6705c5b3213a"), "dGVzdF8x", "test@gmail.com", "Test", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("e134f2b0-c5b6-4c7e-82c5-6a6fc033d62e"), "User" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[] { new Guid("78f79914-1bd2-4aa8-a69b-c1c5f2691896"), new Guid("b4f269e4-07c2-422b-b358-b16492505f73"), "Смартфоны" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("3dc4d6c0-0b26-4f90-9a07-297c828924b8"), new Guid("f78716a2-6240-495c-b0a0-41e2b322d208"), "dGVzdF8x", new DateTime(2022, 11, 6, 15, 42, 11, 897, DateTimeKind.Local).AddTicks(1866), "test@gmail.com", "Test", "127.0.0.1", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("e134f2b0-c5b6-4c7e-82c5-6a6fc033d62e"), "User" },
                    { new Guid("5221fe2f-7ab0-4e88-b65f-af7e4270898e"), new Guid("f78716a2-6240-495c-b0a0-41e2b322d208"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 11, 6, 15, 42, 11, 897, DateTimeKind.Local).AddTicks(1802), "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("e134f2b0-c5b6-4c7e-82c5-6a6fc033d62e"), "Абубакр" }
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
                name: "IX_Categories_BrandId",
                table: "Categories",
                column: "BrandId");

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
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
