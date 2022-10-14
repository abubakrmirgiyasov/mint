using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    public partial class CategoryAndPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4d9cf464-5a60-4a01-9623-961a2224d865"), "Deliver" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c728e145-da15-466e-b58e-f96ba7deabb3"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d22d6248-5b12-4063-b74a-42bb1e14fece"), "Buyer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("12d4567f-edc5-4279-a279-2bf29f0b88ad"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 14, 19, 57, 47, 715, DateTimeKind.Local).AddTicks(1946), "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("c728e145-da15-466e-b58e-f96ba7deabb3"), "Абубакр" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("a43206c9-12ed-49c5-b86e-d6c739b26671"), "dGVzdF8x", new DateTime(2022, 10, 14, 19, 57, 47, 715, DateTimeKind.Local).AddTicks(1983), "test@gmail.com", "Test", true, "", 0, "dGVzdF8x", 89502768428L, new Guid("d22d6248-5b12-4063-b74a-42bb1e14fece"), "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d9cf464-5a60-4a01-9623-961a2224d865"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12d4567f-edc5-4279-a279-2bf29f0b88ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a43206c9-12ed-49c5-b86e-d6c739b26671"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c728e145-da15-466e-b58e-f96ba7deabb3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d22d6248-5b12-4063-b74a-42bb1e14fece"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Photos");

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
        }
    }
}
