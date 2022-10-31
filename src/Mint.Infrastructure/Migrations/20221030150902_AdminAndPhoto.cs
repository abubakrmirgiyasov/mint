using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    public partial class AdminAndPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("611fb824-68b8-43df-a5f3-9d92cd1c79ba"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("4bdf8769-75fa-4bb9-b638-203dadd504f9"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("593e90aa-71e1-4872-8e38-4006cebe72c9"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("682b968f-f38d-494d-86da-eb3406d020ac"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("826b6dfd-69fc-44b9-8c0b-3b0905ad37d5"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("914db199-c42c-43ac-bfef-de993eb83cfb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6f52e195-1f17-4827-88dd-f93e07867819"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ea7a394-fdb0-4b4d-8a6c-5070b7be78ae"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("213e788c-5f27-4669-96ee-e95a30e9105f"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0d9ff98-04d8-483c-bf5e-3b15b5cf2037"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("695b4d9d-cc94-4826-be91-fc3b1fd10f11"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e2147fb1-0a85-4a16-b90c-9bf9c42c83dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ab57d1d-0b9e-4216-a2fd-13a082777047"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Admins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumOfAttempts",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"), "Смартфоны" },
                    { new Guid("7e42480a-e0bc-46bb-9391-2e7dae90ec60"), "Аксессуары" },
                    { new Guid("e39534b6-8d29-4e72-b19e-a979719763af"), "Гаджеты" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3f163607-5132-42cc-9d76-f781423dcd81"), "Россия" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25f10de6-c2d6-4fa6-a971-dc66cbe49029"), "Deliver" },
                    { new Guid("ade0a62e-9596-42bd-ac12-2c388035938f"), "Buyer" },
                    { new Guid("eda63245-1f16-4f26-a74d-0a538b640e34"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "Home", "PostCode", "Street" },
                values: new object[,]
                {
                    { new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"), "Test", new Guid("3f163607-5132-42cc-9d76-f781423dcd81"), "г. Test Street, ком. 302", "302", 123456, "Street" },
                    { new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"), "Новокузнецк", new Guid("3f163607-5132-42cc-9d76-f781423dcd81"), "г. Новокузнецк ул. Бардина 23, ком. 302", "302", 640000, "Бардина 23" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("133ec355-adc1-4cf3-82b1-dc4e5e795c46"), new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"), "Xiaomi" },
                    { new Guid("30a4eea0-9ff8-4eae-96d9-f9596cf8abe9"), new Guid("e39534b6-8d29-4e72-b19e-a979719763af"), "Умные брелоки" },
                    { new Guid("53f6d744-e2e4-4ba3-b082-b2e69c5ae695"), new Guid("7e42480a-e0bc-46bb-9391-2e7dae90ec60"), "Смарт часы" },
                    { new Guid("72467801-1688-4223-8309-1a3ee8977d4f"), new Guid("e39534b6-8d29-4e72-b19e-a979719763af"), "Экшн-камеры" },
                    { new Guid("8742acfc-c03f-4e51-8427-df895c901b6d"), new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"), "Apple Iphone" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "Email", "FirstName", "IsActive", "LastName", "NumOfAttempts", "Password", "Phone", "SecondName" },
                values: new object[,]
                {
                    { new Guid("31d81c07-c4d7-439e-b87e-df1c5f8e5dec"), new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", "abubakrmirgiyasov@gmail.com", "Миргиясов", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, "Абубакр" },
                    { new Guid("8bce750b-3d3f-46a1-bd3e-10781d4bc20c"), new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"), "dGVzdF8x", "test@gmail.com", "Test", true, null, 0, "dGVzdF8x", 89502768529L, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { new Guid("7d42bb87-7150-4e6c-a14b-eeffd3ba62b2"), new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 30, 22, 9, 1, 910, DateTimeKind.Local).AddTicks(5984), "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("eda63245-1f16-4f26-a74d-0a538b640e34"), "Абубакр" },
                    { new Guid("e2b72330-582c-4fa0-b62f-8f3e64be49b6"), new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"), "dGVzdF8x", new DateTime(2022, 10, 30, 22, 9, 1, 910, DateTimeKind.Local).AddTicks(6024), "test@gmail.com", "Test", "127.0.0.1", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("ade0a62e-9596-42bd-ac12-2c388035938f"), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdminId",
                table: "Photos",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Admins_AdminId",
                table: "Photos",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Admins_AdminId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AdminId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("31d81c07-c4d7-439e-b87e-df1c5f8e5dec"));

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("8bce750b-3d3f-46a1-bd3e-10781d4bc20c"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("133ec355-adc1-4cf3-82b1-dc4e5e795c46"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("30a4eea0-9ff8-4eae-96d9-f9596cf8abe9"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("53f6d744-e2e4-4ba3-b082-b2e69c5ae695"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("72467801-1688-4223-8309-1a3ee8977d4f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8742acfc-c03f-4e51-8427-df895c901b6d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("25f10de6-c2d6-4fa6-a971-dc66cbe49029"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d42bb87-7150-4e6c-a14b-eeffd3ba62b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2b72330-582c-4fa0-b62f-8f3e64be49b6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("62d3d79f-56c5-4cbb-b7ac-ddfd9aeec07b"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("71c16160-7e5c-4a07-b6e4-47ea2246c77f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2bc95fc6-54f7-4316-a305-4c0fb5767296"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e42480a-e0bc-46bb-9391-2e7dae90ec60"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e39534b6-8d29-4e72-b19e-a979719763af"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ade0a62e-9596-42bd-ac12-2c388035938f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eda63245-1f16-4f26-a74d-0a538b640e34"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3f163607-5132-42cc-9d76-f781423dcd81"));

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NumOfAttempts",
                table: "Admins");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"), "Гаджеты" },
                    { new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"), "Смартфоны" },
                    { new Guid("f0d9ff98-04d8-483c-bf5e-3b15b5cf2037"), "Аксессуары" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3ab57d1d-0b9e-4216-a2fd-13a082777047"), "Россия" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("695b4d9d-cc94-4826-be91-fc3b1fd10f11"), "Admin" },
                    { new Guid("6f52e195-1f17-4827-88dd-f93e07867819"), "Deliver" },
                    { new Guid("e2147fb1-0a85-4a16-b90c-9bf9c42c83dc"), "Buyer" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "Home", "PostCode", "Street" },
                values: new object[] { new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"), "Новокузнецк", new Guid("3ab57d1d-0b9e-4216-a2fd-13a082777047"), "г. Новокузнецк ул. Бардина 23, ком. 302", "302", 640000, "Бардина 23" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("4bdf8769-75fa-4bb9-b638-203dadd504f9"), new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"), "Xiaomi" },
                    { new Guid("593e90aa-71e1-4872-8e38-4006cebe72c9"), new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"), "Умные брелоки" },
                    { new Guid("682b968f-f38d-494d-86da-eb3406d020ac"), new Guid("f0d9ff98-04d8-483c-bf5e-3b15b5cf2037"), "Смарт часы" },
                    { new Guid("826b6dfd-69fc-44b9-8c0b-3b0905ad37d5"), new Guid("32cbd5d9-8d27-4982-b3b8-eefefde14519"), "Экшн-камеры" },
                    { new Guid("914db199-c42c-43ac-bfef-de993eb83cfb"), new Guid("9aef5baa-3fed-4dac-a93e-6539e8358ac8"), "Apple Iphone" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "Email", "FirstName", "LastName", "Password", "Phone", "SecondName" },
                values: new object[] { new Guid("611fb824-68b8-43df-a5f3-9d92cd1c79ba"), new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", "abubakrmirgiyasov@gmail.com", "Миргиясов", "Мукимжонович", "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, "Абубакр" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("1ea7a394-fdb0-4b4d-8a6c-5070b7be78ae"), new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"), "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", new DateTime(2022, 10, 30, 18, 46, 51, 541, DateTimeKind.Local).AddTicks(7889), "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, "Мукимжонович", 0, "QWJ1YWtyTWlyZ2l5YXNvdkApKSFN", 89502768428L, new Guid("695b4d9d-cc94-4826-be91-fc3b1fd10f11"), "Абубакр" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "ConfirmedPassword", "CreatedDate", "Email", "FirstName", "Ip", "IsActiveAccount", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[] { new Guid("213e788c-5f27-4669-96ee-e95a30e9105f"), new Guid("83ddb109-4c6b-45d8-bfc1-1cadf4ef5282"), "dGVzdF8x", new DateTime(2022, 10, 30, 18, 46, 51, 541, DateTimeKind.Local).AddTicks(7929), "test@gmail.com", "Test", "127.0.0.2", true, null, 0, "dGVzdF8x", 89502768529L, new Guid("e2147fb1-0a85-4a16-b90c-9bf9c42c83dc"), "User" });
        }
    }
}
