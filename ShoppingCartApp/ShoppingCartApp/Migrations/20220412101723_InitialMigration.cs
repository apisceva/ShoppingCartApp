using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    InStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Bakery", "Bakery Products" },
                    { 2, "Vegetables", "All Vegetables" },
                    { 3, "Fruits", "All Fruits" },
                    { 4, "Drinks", "All Drinks" },
                    { 5, "Meat", "All Meat" },
                    { 6, "Snacks", "All Snacks" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImageUrl", "InStock", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, "", true, "The products prepared in the oven can contain as ingredients or as traces the following allergens: gluten, crustaceans shellfish, eggs, fish, peanuts, soybean, milk and dairy products, tree nuts, celery, mustard, sesame, sulphites, lupin and molluscan shellfish.", "Rustic Bread", 1.45m, "Rustic Bread" },
                    { 2, 2, "", true, "Dulcita cherry on the vine tomatoes", "Cherry Tomatoes", 2.69m, "Cherry Tomatoes" },
                    { 3, 3, "", true, " ", "Golden Apple", 0.38m, "Piece 210 g approx. | 1,79 €/kg" },
                    { 4, 4, "", true, " ", "Coca-Cola", 1.84m, "Coca-Cola soft drink, 2L" },
                    { 5, 5, "", true, " ", "Fleshy chunks pork ribs", 3.54m, "Tray 530 g approx. | 6,67 €/kg" },
                    { 6, 6, "", true, " ", "Lay's Ready salted crisps", 1.48m, "Package 207 g | 7,15 €/kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
