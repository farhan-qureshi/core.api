using Microsoft.EntityFrameworkCore.Migrations;

namespace core.api.commerce.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SubProducts",
                columns: table => new
                {
                    SubProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProducts", x => x.SubProductId);
                    table.ForeignKey(
                        name: "FK_SubProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Title" },
                values: new object[] { 1, "first product description", "first product title" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Title" },
                values: new object[] { 2, "second product description", "second product title" });

            migrationBuilder.InsertData(
                table: "SubProducts",
                columns: new[] { "SubProductId", "Description", "ProductId", "Title" },
                values: new object[] { 1, "sub product 1", 1, "first sub product" });

            migrationBuilder.InsertData(
                table: "SubProducts",
                columns: new[] { "SubProductId", "Description", "ProductId", "Title" },
                values: new object[] { 3, "sub product 3", 1, "third sub product" });

            migrationBuilder.InsertData(
                table: "SubProducts",
                columns: new[] { "SubProductId", "Description", "ProductId", "Title" },
                values: new object[] { 2, "sub product 2", 2, "second sub product" });

            migrationBuilder.CreateIndex(
                name: "IX_SubProducts_ProductId",
                table: "SubProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProducts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
