using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateSystem.Data.Migrations
{
    public partial class LinkCorectionInHouseSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("03cca288-0a34-40d5-93ba-87840afb7fd9"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("50ae795e-89d1-4d24-ae26-5781a4ca120c"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("6eeee4cc-bca1-46eb-9533-a8d0f19e1abb"));

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("59fcc9a9-a7be-4025-9762-14e8669d41df"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("8574ae47-bdeb-4974-83ad-e462445bcc81"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("d0b04a54-c475-4821-850d-5261862ac263"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("842c3156-8794-4456-aaa6-e67f1821eafe"), "Big House Marina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("59fcc9a9-a7be-4025-9762-14e8669d41df"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("8574ae47-bdeb-4974-83ad-e462445bcc81"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("d0b04a54-c475-4821-850d-5261862ac263"));

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("03cca288-0a34-40d5-93ba-87840afb7fd9"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a & o = &hp = 1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("50ae795e-89d1-4d24-ae26-5781a4ca120c"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("842c3156-8794-4456-aaa6-e67f1821eafe"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("6eeee4cc-bca1-46eb-9533-a8d0f19e1abb"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });
        }
    }
}
