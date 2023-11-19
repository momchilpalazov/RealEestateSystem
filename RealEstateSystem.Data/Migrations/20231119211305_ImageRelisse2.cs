using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateSystem.Data.Migrations
{
    public partial class ImageRelisse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses");

            migrationBuilder.DropIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.AddColumn<int>(
                name: "ImageId1",
                table: "Hauses",
                type: "int",
                nullable: true);

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
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hauses_Images_ImageId1",
                table: "Hauses",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Hauses");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hauses_ImageId",
                table: "Hauses",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hauses_Images_ImageId",
                table: "Hauses",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
