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
                        principalColumn: "Id");
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ee050e0-f246-4596-8b8e-53a12cc21682"), "Гаджеты" },
                    { new Guid("989627bc-78f5-487c-bc2f-547e20d1fb3e"), "Аксессуары" },
                    { new Guid("e5b6c6b6-530b-4892-93f9-26df9fe2a5fa"), "Смартфоны" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7c086e4d-51c3-4ebd-aeb0-c7aa296f4b64"), "Deliver" },
                    { new Guid("85458502-98ca-4394-a6d2-a4fa8af31289"), "Admin" },
                    { new Guid("9f464205-6426-47b8-8049-ffe6cc4aa514"), "Buyer" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("067657a0-190c-4173-9f0c-72e3b88050f7"), new Guid("e5b6c6b6-530b-4892-93f9-26df9fe2a5fa"), "Apple Iphone" },
                    { new Guid("a8049977-b75a-4ee5-972a-63a4ef9b80a6"), new Guid("e5b6c6b6-530b-4892-93f9-26df9fe2a5fa"), "Xiaomi" },
                    { new Guid("bf2d521f-cc0d-404f-ab13-9debd5f8faf3"), new Guid("2ee050e0-f246-4596-8b8e-53a12cc21682"), "Умные брелоки" },
                    { new Guid("c48a3038-5387-42ab-a109-04b3b9a80877"), new Guid("2ee050e0-f246-4596-8b8e-53a12cc21682"), "Экшн-камеры" },
                    { new Guid("edacf4c8-470e-4b77-b0b6-b11206b6b61f"), new Guid("989627bc-78f5-487c-bc2f-547e20d1fb3e"), "Смарт часы" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("8d4e1468-61b3-4dbb-9fb5-4ac97003c193"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 21, 20, 0, 44, 317, DateTimeKind.Local).AddTicks(5684), "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("85458502-98ca-4394-a6d2-a4fa8af31289"), "Абубакр" },
                    { new Guid("b3532bb2-36a2-4d19-bdc8-3e766d1e387e"), "dGVzdF8x", new DateTime(2022, 10, 21, 20, 0, 44, 317, DateTimeKind.Local).AddTicks(5752), "test@gmail.com", "Test", "127.0.0.2", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("9f464205-6426-47b8-8049-ffe6cc4aa514"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BrandId",
                table: "Photos",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

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
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
