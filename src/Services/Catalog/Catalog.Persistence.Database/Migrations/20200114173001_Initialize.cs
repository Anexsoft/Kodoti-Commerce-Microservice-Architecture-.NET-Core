using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 739m },
                    { 73, "Description for product 73", "Product 73", 545m },
                    { 72, "Description for product 72", "Product 72", 620m },
                    { 71, "Description for product 71", "Product 71", 549m },
                    { 70, "Description for product 70", "Product 70", 451m },
                    { 69, "Description for product 69", "Product 69", 329m },
                    { 68, "Description for product 68", "Product 68", 174m },
                    { 67, "Description for product 67", "Product 67", 188m },
                    { 66, "Description for product 66", "Product 66", 888m },
                    { 65, "Description for product 65", "Product 65", 660m },
                    { 64, "Description for product 64", "Product 64", 211m },
                    { 63, "Description for product 63", "Product 63", 462m },
                    { 62, "Description for product 62", "Product 62", 903m },
                    { 61, "Description for product 61", "Product 61", 227m },
                    { 60, "Description for product 60", "Product 60", 145m },
                    { 59, "Description for product 59", "Product 59", 598m },
                    { 58, "Description for product 58", "Product 58", 159m },
                    { 57, "Description for product 57", "Product 57", 158m },
                    { 56, "Description for product 56", "Product 56", 208m },
                    { 55, "Description for product 55", "Product 55", 835m },
                    { 54, "Description for product 54", "Product 54", 912m },
                    { 53, "Description for product 53", "Product 53", 544m },
                    { 74, "Description for product 74", "Product 74", 908m },
                    { 52, "Description for product 52", "Product 52", 548m },
                    { 75, "Description for product 75", "Product 75", 795m },
                    { 77, "Description for product 77", "Product 77", 243m },
                    { 98, "Description for product 98", "Product 98", 375m },
                    { 97, "Description for product 97", "Product 97", 113m },
                    { 96, "Description for product 96", "Product 96", 846m },
                    { 95, "Description for product 95", "Product 95", 322m },
                    { 94, "Description for product 94", "Product 94", 689m },
                    { 93, "Description for product 93", "Product 93", 389m },
                    { 92, "Description for product 92", "Product 92", 156m },
                    { 91, "Description for product 91", "Product 91", 269m },
                    { 90, "Description for product 90", "Product 90", 629m },
                    { 89, "Description for product 89", "Product 89", 530m },
                    { 88, "Description for product 88", "Product 88", 857m },
                    { 87, "Description for product 87", "Product 87", 441m },
                    { 86, "Description for product 86", "Product 86", 479m },
                    { 85, "Description for product 85", "Product 85", 254m },
                    { 84, "Description for product 84", "Product 84", 504m },
                    { 83, "Description for product 83", "Product 83", 392m },
                    { 82, "Description for product 82", "Product 82", 748m },
                    { 81, "Description for product 81", "Product 81", 904m },
                    { 80, "Description for product 80", "Product 80", 352m },
                    { 79, "Description for product 79", "Product 79", 932m },
                    { 78, "Description for product 78", "Product 78", 418m },
                    { 76, "Description for product 76", "Product 76", 719m },
                    { 51, "Description for product 51", "Product 51", 482m },
                    { 50, "Description for product 50", "Product 50", 801m },
                    { 49, "Description for product 49", "Product 49", 732m },
                    { 22, "Description for product 22", "Product 22", 630m },
                    { 21, "Description for product 21", "Product 21", 194m },
                    { 20, "Description for product 20", "Product 20", 544m },
                    { 19, "Description for product 19", "Product 19", 358m },
                    { 18, "Description for product 18", "Product 18", 280m },
                    { 17, "Description for product 17", "Product 17", 507m },
                    { 16, "Description for product 16", "Product 16", 665m },
                    { 15, "Description for product 15", "Product 15", 679m },
                    { 14, "Description for product 14", "Product 14", 967m },
                    { 13, "Description for product 13", "Product 13", 440m },
                    { 12, "Description for product 12", "Product 12", 859m },
                    { 11, "Description for product 11", "Product 11", 775m },
                    { 10, "Description for product 10", "Product 10", 588m },
                    { 9, "Description for product 9", "Product 9", 747m },
                    { 8, "Description for product 8", "Product 8", 668m },
                    { 7, "Description for product 7", "Product 7", 928m },
                    { 6, "Description for product 6", "Product 6", 141m },
                    { 5, "Description for product 5", "Product 5", 523m },
                    { 4, "Description for product 4", "Product 4", 903m },
                    { 3, "Description for product 3", "Product 3", 251m },
                    { 2, "Description for product 2", "Product 2", 166m },
                    { 23, "Description for product 23", "Product 23", 108m },
                    { 24, "Description for product 24", "Product 24", 191m },
                    { 25, "Description for product 25", "Product 25", 405m },
                    { 26, "Description for product 26", "Product 26", 477m },
                    { 48, "Description for product 48", "Product 48", 264m },
                    { 47, "Description for product 47", "Product 47", 573m },
                    { 46, "Description for product 46", "Product 46", 153m },
                    { 45, "Description for product 45", "Product 45", 259m },
                    { 44, "Description for product 44", "Product 44", 689m },
                    { 43, "Description for product 43", "Product 43", 487m },
                    { 42, "Description for product 42", "Product 42", 475m },
                    { 41, "Description for product 41", "Product 41", 749m },
                    { 40, "Description for product 40", "Product 40", 450m },
                    { 39, "Description for product 39", "Product 39", 735m },
                    { 99, "Description for product 99", "Product 99", 129m },
                    { 38, "Description for product 38", "Product 38", 887m },
                    { 36, "Description for product 36", "Product 36", 327m },
                    { 35, "Description for product 35", "Product 35", 738m },
                    { 34, "Description for product 34", "Product 34", 366m },
                    { 33, "Description for product 33", "Product 33", 770m },
                    { 32, "Description for product 32", "Product 32", 886m },
                    { 31, "Description for product 31", "Product 31", 928m },
                    { 30, "Description for product 30", "Product 30", 636m },
                    { 29, "Description for product 29", "Product 29", 306m },
                    { 28, "Description for product 28", "Product 28", 124m },
                    { 27, "Description for product 27", "Product 27", 913m },
                    { 37, "Description for product 37", "Product 37", 216m },
                    { 100, "Description for product 100", "Product 100", 370m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 17 },
                    { 73, 73, 11 },
                    { 72, 72, 7 },
                    { 71, 71, 10 },
                    { 70, 70, 4 },
                    { 69, 69, 11 },
                    { 68, 68, 13 },
                    { 67, 67, 2 },
                    { 66, 66, 2 },
                    { 65, 65, 14 },
                    { 64, 64, 7 },
                    { 63, 63, 13 },
                    { 62, 62, 7 },
                    { 61, 61, 5 },
                    { 60, 60, 0 },
                    { 59, 59, 8 },
                    { 58, 58, 11 },
                    { 57, 57, 9 },
                    { 56, 56, 18 },
                    { 55, 55, 17 },
                    { 54, 54, 6 },
                    { 53, 53, 15 },
                    { 74, 74, 16 },
                    { 52, 52, 15 },
                    { 75, 75, 2 },
                    { 77, 77, 18 },
                    { 98, 98, 13 },
                    { 97, 97, 8 },
                    { 96, 96, 18 },
                    { 95, 95, 19 },
                    { 94, 94, 13 },
                    { 93, 93, 13 },
                    { 92, 92, 4 },
                    { 91, 91, 7 },
                    { 90, 90, 7 },
                    { 89, 89, 19 },
                    { 88, 88, 0 },
                    { 87, 87, 7 },
                    { 86, 86, 3 },
                    { 85, 85, 10 },
                    { 84, 84, 0 },
                    { 83, 83, 5 },
                    { 82, 82, 12 },
                    { 81, 81, 0 },
                    { 80, 80, 14 },
                    { 79, 79, 3 },
                    { 78, 78, 17 },
                    { 76, 76, 12 },
                    { 51, 51, 5 },
                    { 50, 50, 10 },
                    { 49, 49, 18 },
                    { 22, 22, 19 },
                    { 21, 21, 14 },
                    { 20, 20, 8 },
                    { 19, 19, 0 },
                    { 18, 18, 5 },
                    { 17, 17, 9 },
                    { 16, 16, 6 },
                    { 15, 15, 0 },
                    { 14, 14, 16 },
                    { 13, 13, 9 },
                    { 12, 12, 9 },
                    { 11, 11, 5 },
                    { 10, 10, 13 },
                    { 9, 9, 3 },
                    { 8, 8, 4 },
                    { 7, 7, 11 },
                    { 6, 6, 16 },
                    { 5, 5, 13 },
                    { 4, 4, 10 },
                    { 3, 3, 18 },
                    { 2, 2, 8 },
                    { 23, 23, 19 },
                    { 24, 24, 6 },
                    { 25, 25, 1 },
                    { 26, 26, 13 },
                    { 48, 48, 18 },
                    { 47, 47, 12 },
                    { 46, 46, 7 },
                    { 45, 45, 2 },
                    { 44, 44, 2 },
                    { 43, 43, 0 },
                    { 42, 42, 2 },
                    { 41, 41, 6 },
                    { 40, 40, 4 },
                    { 39, 39, 13 },
                    { 99, 99, 7 },
                    { 38, 38, 2 },
                    { 36, 36, 16 },
                    { 35, 35, 5 },
                    { 34, 34, 16 },
                    { 33, 33, 6 },
                    { 32, 32, 3 },
                    { 31, 31, 18 },
                    { 30, 30, 16 },
                    { 29, 29, 10 },
                    { 28, 28, 4 },
                    { 27, 27, 10 },
                    { 37, 37, 16 },
                    { 100, 100, 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
