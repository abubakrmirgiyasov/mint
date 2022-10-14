using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    public partial class UserAndPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("beab503a-f069-4501-a2d3-f76c306b65ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01064f77-0f87-40f8-9c69-fbd3f59b7186"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ce936cc-d459-4ff1-808f-4cd8bccf557f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fa260391-177a-45b1-9c69-143b5c857b66"));

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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0c145641-e847-46c9-a1f2-7b443c2c4897"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4834bf3d-58d7-43af-a48c-e5ed1da4fb9e"), "Buyer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("6befe321-5790-42ec-a8d5-907b7e3b403e"), "dGVzdF8x", new DateTime(2022, 10, 14, 19, 50, 21, 433, DateTimeKind.Local).AddTicks(8483), "test@gmail.com", "Test", true, "", 0, "dGVzdF8x", 89502768428L, new Guid("4834bf3d-58d7-43af-a48c-e5ed1da4fb9e"), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("c34df810-9cad-414a-a710-03ad6a9a7904"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 14, 19, 50, 21, 433, DateTimeKind.Local).AddTicks(8443), "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("0c145641-e847-46c9-a1f2-7b443c2c4897"), "Абубакр" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6befe321-5790-42ec-a8d5-907b7e3b403e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c34df810-9cad-414a-a710-03ad6a9a7904"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c145641-e847-46c9-a1f2-7b443c2c4897"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4834bf3d-58d7-43af-a48c-e5ed1da4fb9e"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("beab503a-f069-4501-a2d3-f76c306b65ac"), "Buyer" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fa260391-177a-45b1-9c69-143b5c857b66"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("01064f77-0f87-40f8-9c69-fbd3f59b7186"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 7, 17, 55, 20, 70, DateTimeKind.Local).AddTicks(6458), "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("fa260391-177a-45b1-9c69-143b5c857b66"), "Абубакр" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("5ce936cc-d459-4ff1-808f-4cd8bccf557f"), "dGVzdF8x", new DateTime(2022, 10, 7, 17, 55, 20, 70, DateTimeKind.Local).AddTicks(6494), "test@gmail.com", "Test", true, "", 0, "dGVzdF8x", 89502768428L, new Guid("fa260391-177a-45b1-9c69-143b5c857b66"), "User" });
        }
    }
}
