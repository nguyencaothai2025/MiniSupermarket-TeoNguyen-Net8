using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class Chay_lan_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "893456789001", 1, 12500m, "Snack Khoai Tây O'Star Gói 60g", 150 },
                    { 2, "893456789002", 1, 135000m, "Bánh Quy Bơ Danisa Hộp Thiếc 454g", 40 },
                    { 3, "893456789003", 2, 10000m, "Nước Ngọt Coca Cola Lon 320ml", 320 },
                    { 4, "893456789004", 2, 6000m, "Nước Khoáng Lavie Chai 500ml", 200 },
                    { 5, "893456789005", 3, 34500m, "Sữa Tươi Tiệt Trùng Vinamilk 1L", 85 },
                    { 6, "893456789006", 4, 4500m, "Mì Tôm Hảo Hảo Chua Cay Gói 75g", 500 },
                    { 7, "893456789007", 5, 125000m, "Dầu Ăn Simply Nguyên Chất Can 2L", 45 },
                    { 8, "893456789008", 5, 30000m, "Nước Mắm Nam Ngư Chai 900ml", 90 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);
        }
    }
}
