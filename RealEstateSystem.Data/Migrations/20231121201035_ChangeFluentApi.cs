using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateSystem.Data.Migrations
{
    public partial class ChangeFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses");

            migrationBuilder.DropForeignKey(
                name: "FK_Hauses_Images_ImageId1",
                table: "Hauses");

            migrationBuilder.DropIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses");

            migrationBuilder.DropIndex(
                name: "IX_Hauses_ImageId1",
                table: "Hauses");

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("3927fd63-2364-4ef6-ad06-04c8f46c0e2e"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("677a00ad-f73f-42ea-b6b8-b11715aeada0"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("9f696454-556c-419e-9ee7-80aa44ff4fb1"));

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Hauses");

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("3e62c3de-0216-474e-9d74-2788f2da155b"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("ab548cde-f854-44b0-b8d5-6210b0de6dfc"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("af094284-866f-4120-8493-47a93a606df0"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.CreateIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses");

            migrationBuilder.DropIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses");

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("3e62c3de-0216-474e-9d74-2788f2da155b"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("ab548cde-f854-44b0-b8d5-6210b0de6dfc"));

            migrationBuilder.DeleteData(
                table: "Hauses",
                keyColumn: "Id",
                keyValue: new Guid("af094284-866f-4120-8493-47a93a606df0"));

            migrationBuilder.AddColumn<int>(
                name: "ImageId1",
                table: "Hauses",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageId1", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("3927fd63-2364-4ef6-ad06-04c8f46c0e2e"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", null, null, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageId1", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("677a00ad-f73f-42ea-b6b8-b11715aeada0"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 1, "This luxurious house is everything you will need. It is just excellent.", null, null, "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Hauses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageId", "ImageId1", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("9f696454-556c-419e-9ee7-80aa44ff4fb1"), "North London, UK (near the border)", new Guid("723b08eb-551c-4f19-a202-8b83cd44568f"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", null, null, "https://www.luxury-architecture.net/wp-content/uploads/2022/07/MMP-146688.jpg", 2100.00m, new Guid("1a590882-b95f-4ff1-aae0-263398eea736"), "Big House Marina" });

            migrationBuilder.CreateIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hauses_ImageId1",
                table: "Hauses",
                column: "ImageId1",
                unique: true,
                filter: "[ImageId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hauses_Images_ImageId1",
                table: "Hauses",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
