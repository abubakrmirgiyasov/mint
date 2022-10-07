using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    public partial class UserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
