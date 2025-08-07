using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets like phones, laptops, and TVs.", "Electronics" },
                    { 2, "A wide variety of books from fiction to non-fiction.", "Books" },
                    { 3, "Apparel for men, women, and children of all ages.", "Clothing" },
                    { 4, "Items to decorate and furnish your home beautifully.", "Home Decor" },
                    { 5, "Gear and clothing for different types of sports activities.", "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "ahmed.ali@example.com", "Ahmed", "Ali", "Password123" },
                    { 2, "mona.hassan@example.com", "Mona", "Hassan", "MonaPass456" },
                    { 3, "khaled.youssef@example.com", "Khaled", "Youssef", "Khaled789!" },
                    { 4, "salma.ibrahim@example.com", "Salma", "Ibrahim", "SalmaPass12" },
                    { 5, "tamer.saad@example.com", "Tamer", "Saad", "Tamer_12345" },
                    { 6, "rana.farouk@example.com", "Rana", "Farouk", "RanaPass987" },
                    { 7, "youssef.hamed@example.com", "Youssef", "Hamed", "Youss_2023" },
                    { 8, "nour.gamal@example.com", "Nour", "Gamal", "NourPass321" },
                    { 9, "omar.elsayed@example.com", "Omar", "ElSayed", "OmarPass444" },
                    { 10, "laila.adel@example.com", "Laila", "Adel", "Laila2022$" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Latest model with powerful processor and camera.", "images/smartphone.jpg", 8999.99m, 50, "Smartphone" },
                    { 2, 5, "Comfortable and durable shoes for daily running.", "images/shoes.jpg", 799.50m, 100, "Running Shoes" },
                    { 3, 3, "Genuine leather wallet with multiple card slots.", "images/wallet.jpg", 299.00m, 75, "Leather Wallet" },
                    { 4, 1, "Wireless headphones with noise cancellation.", "images/headphones.jpg", 1299.99m, 30, "Bluetooth Headphones" },
                    { 5, 2, "Bestselling novel with an intriguing storyline.", "images/novel.jpg", 99.00m, 80, "Fiction Novel" },
                    { 6, 4, "LED table lamp with adjustable brightness.", "images/lamp.jpg", 399.50m, 90, "Table Lamp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
