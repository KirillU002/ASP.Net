using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b75b71ea-02c8-4d56-b804-08db5dda9ca9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff2845b8-f032-4716-6b29-08db5dd4d1a6"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
