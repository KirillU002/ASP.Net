using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4177b5df-8651-4aee-9b97-559082d80f1a"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("b1422808-5cee-4bd2-a2d9-5e6081d7b0ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b75b71ea-02c8-4d56-b804-08db5dda9ca9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff2845b8-f032-4716-6b29-08db5dd4d1a6"));

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteProductId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Company", "Cost", "Description", "Diagonal", "Hz", "Matrix", "Name", "Response", "ScreenResolution" },
                values: new object[,]
                {
                    { new Guid("48240a82-9f6b-414c-97f4-f624813149b2"), "Белый", "Леново", 2323m, "Самый кртуой в мире монитор", "23 дюйма", "144 Гц", "ва", "Name1", "1 мс", "1920х1080" },
                    { new Guid("befe6b5b-7171-4446-b35c-5b265b81be17"), "Белый", "Монитор", 545665m, "Самый кртуой в мире монитор", "23 дюйма", "144 Гц", "ва", "Name2", "1 мс", "1920х1080" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "FavoriteProductId", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("93aca5ca-a2b0-4c52-a2cd-c29dbbad8949"), null, new Guid("48240a82-9f6b-414c-97f4-f624813149b2"), "/images/Products/image3.png" },
                    { new Guid("eeec8f03-a320-47ac-b97e-0af9cd17cb41"), null, new Guid("befe6b5b-7171-4446-b35c-5b265b81be17"), "/images/Products/image4.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_FavoriteProductId",
                table: "Image",
                column: "FavoriteProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_FavoriteProducts_FavoriteProductId",
                table: "Image",
                column: "FavoriteProductId",
                principalTable: "FavoriteProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_FavoriteProducts_FavoriteProductId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_FavoriteProductId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("93aca5ca-a2b0-4c52-a2cd-c29dbbad8949"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("eeec8f03-a320-47ac-b97e-0af9cd17cb41"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48240a82-9f6b-414c-97f4-f624813149b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("befe6b5b-7171-4446-b35c-5b265b81be17"));

            migrationBuilder.DropColumn(
                name: "FavoriteProductId",
                table: "Image");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Company", "Cost", "Description", "Diagonal", "Hz", "Matrix", "Name", "Response", "ScreenResolution" },
                values: new object[,]
                {
                    { new Guid("b75b71ea-02c8-4d56-b804-08db5dda9ca9"), "Белый", "Монитор", 545665m, "Самый кртуой в мире монитор", "23 дюйма", "144 Гц", "ва", "Name2", "1 мс", "1920х1080" },
                    { new Guid("ff2845b8-f032-4716-6b29-08db5dd4d1a6"), "Белый", "Леново", 2323m, "Самый кртуой в мире монитор", "23 дюйма", "144 Гц", "ва", "Name1", "1 мс", "1920х1080" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("4177b5df-8651-4aee-9b97-559082d80f1a"), new Guid("ff2845b8-f032-4716-6b29-08db5dd4d1a6"), "/images/Products/image1.jpg" },
                    { new Guid("b1422808-5cee-4bd2-a2d9-5e6081d7b0ea"), new Guid("b75b71ea-02c8-4d56-b804-08db5dda9ca9"), "/images/Products/image2.jpg" }
                });
        }
    }
}
