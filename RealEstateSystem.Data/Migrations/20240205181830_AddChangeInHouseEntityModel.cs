using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateSystem.Data.Migrations
{
    public partial class AddChangeInHouseEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("46dae025-cea1-4748-9dbd-62b317a31718"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("8fe3489d-3645-4df3-8e8c-3c776c4655eb"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("bbd495b8-ae42-464c-a85d-83583572a8d5"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("e2149e7a-7d26-4790-9d9d-1eb840b10e66"));

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("0e5be39d-e78a-44f2-8f80-964d0c2c8bc7"), "+49888888888", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53f5d2a1-c016-45b5-b273-45c319e02fba", "AQAAAAEAACcQAAAAEDvw1gl8tVBI7yhzxVyF8j+fbQ23NxbYqJnp1NUNE7CU/LqZWxBmkEQN8tSKAmCtGQ==", "F7755186-FBBE-4151-8444-B43F53197212" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("7861d7dc-c959-4fd0-849c-1cee25c0597e"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" },
                    { new Guid("a84792e4-6dd0-40a0-b24f-a2f3850c948f"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("e675c09d-ee03-4abb-8307-b768fd29fb2e"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("0e5be39d-e78a-44f2-8f80-964d0c2c8bc7"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("7861d7dc-c959-4fd0-849c-1cee25c0597e"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("a84792e4-6dd0-40a0-b24f-a2f3850c948f"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("e675c09d-ee03-4abb-8307-b768fd29fb2e"));

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("46dae025-cea1-4748-9dbd-62b317a31718"), "+49888888888", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "739cdfb7-15df-4f20-aefb-b99f1f9048ff", "AQAAAAEAACcQAAAAED7MxdnTGbNiAZSD8KYtffWA4TYvCgI1j2Zr0YhVUguyqlxp4ET+IEdMV/N/icnmeg==", "7A4BE401-3E4F-4649-8A97-2548740021EB" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("8fe3489d-3645-4df3-8e8c-3c776c4655eb"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("bbd495b8-ae42-464c-a85d-83583572a8d5"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("e2149e7a-7d26-4790-9d9d-1eb840b10e66"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" }
                });
        }
    }
}
