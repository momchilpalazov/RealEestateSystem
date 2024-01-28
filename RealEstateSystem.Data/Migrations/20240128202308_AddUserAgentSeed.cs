using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateSystem.Data.Migrations
{
    public partial class AddUserAgentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("0b8e6c6b-7161-4b5c-ab36-4484fa7afd35"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("1b5b744e-fda4-47ec-b0a9-5589cb7c2e92"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("f8ef6d68-1835-4b35-92e3-18077902a9ec"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Adminov",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 0, "512ba971-57db-4507-a7c9-8d48ca3de258", "admin@realestate.de", false, "Great", "Admin", false, null, "ADMIN@REALESTATE.DE", "ADMIN@REALESTATE.DE", "AQAAAAEAACcQAAAAEMz7n7hDI/W30wwh+JGX2fAoghb2mDlV7CCYQ0PIzxgoRWUBCajdWN1bb9r007fsYQ==", null, false, "7B319814-0E59-4B8C-BA96-10B8F8F5A52A", false, "admin@realestate.de" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("0e4e1c03-f95a-4e4d-98c9-f531ea6a372a"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("1da6d485-19d2-497f-9675-dce4a3b91c75"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("46babf30-f81a-4533-ba63-824f7805a93b"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("5323387c-d769-42d8-9202-d502a9afba86"), "+49888888888", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("5323387c-d769-42d8-9202-d502a9afba86"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("0e4e1c03-f95a-4e4d-98c9-f531ea6a372a"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("1da6d485-19d2-497f-9675-dce4a3b91c75"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("46babf30-f81a-4533-ba63-824f7805a93b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Adminov");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Admin");

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("0b8e6c6b-7161-4b5c-ab36-4484fa7afd35"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("1b5b744e-fda4-47ec-b0a9-5589cb7c2e92"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("f8ef6d68-1835-4b35-92e3-18077902a9ec"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" });
        }
    }
}
