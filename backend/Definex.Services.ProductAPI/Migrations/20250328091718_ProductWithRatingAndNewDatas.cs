using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Definex.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductWithRatingAndNewDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, "Casual Dress", "Light and breezy summer dress with beautiful floral pattern. Perfect for casual outings and beach days.", "", "Floral Summer Dress", 50.0, 5 },
                    { 2, "Evening Dress", "Sophisticated evening gown with delicate embellishments. Ideal for formal events and special occasions.", "", "Elegant Evening Gown", 130.0, 4 },
                    { 3, "Office Dress", "Professional and stylish pencil dress for workplace environments. Features a classic cut and comfortable fabric.", "", "Business Pencil Dress", 79.5, 5 },
                    { 4, "Casual Dress", "Flowing maxi dress with bohemian patterns and comfortable fit. Perfect for summer festivals and casual wear.", "", "Bohemian Maxi Dress", 59.990000000000002, 3 },
                    { 5, "Party Dress", "Stylish cocktail dress with modern design. Suitable for parties and semi-formal events.", "", "Cocktail Party Dress", 89.989999999999995, 4 },
                    { 6, "Vintage Dress", "Retro-inspired dress with classic polka dot pattern. Features a flattering A-line silhouette.", "", "Vintage Polka Dot Dress", 65.989999999999995, 5 },
                    { 7, "Formal Dress", "Elegant dress perfect for wedding guests. Balanced between formal and festive for special celebrations.", "", "Wedding Guest Dress", 100.0, 4 },
                    { 8, "Casual Dress", "Classic little black dress that's versatile for multiple occasions. A wardrobe essential.", "", "Little Black Dress", 69.989999999999995, 5 },
                    { 9, "Casual Dress", "Flattering wrap dress design that suits various body types. Comfortable and stylish for everyday wear.", "", "Wrap Dress", 54.990000000000002, 4 },
                    { 10, "Summer Dress", "Practical and cute sundress featuring convenient pockets. Perfect for summer days.", "", "Sundress with Pockets", 45.5, 5 },
                    { 11, "Casual Dress", "Casual denim shirt dress that combines comfort and style. Great for everyday casual looks.", "", "Denim Shirt Dress", 59.990000000000002, 3 },
                    { 12, "Winter Dress", "Warm and cozy sweater dress for cold weather. Features a comfortable fit and high-quality knit fabric.", "", "Winter Sweater Dress", 75.0, 4 },
                    { 13, "Casual Dress", "Classic fit and flare silhouette that flatters many body types. Versatile for various occasions.", "", "Fit and Flare Dress", 68.5, 5 },
                    { 14, "Party Dress", "Eye-catching sequin dress that makes a statement at parties and special events.", "", "Sequin Party Dress", 119.98999999999999, 4 },
                    { 15, "Summer Dress", "Breathable linen dress perfect for hot summer days. Comfortable and effortlessly stylish.", "", "Linen Summer Dress", 65.0, 3 },
                    { 16, "Party Dress", "Figure-hugging bodycon dress that accentuates curves. Great for nights out and social events.", "", "Bodycon Dress", 59.990000000000002, 4 },
                    { 17, "Casual Dress", "Casual and comfortable t-shirt dress. The perfect throw-on-and-go piece for busy days.", "", "T-Shirt Dress", 40.0, 4 },
                    { 18, "Summer Dress", "Stylish halter neck design that highlights shoulders. Great for summer events and parties.", "", "Halter Neck Dress", 69.989999999999995, 3 },
                    { 19, "Formal Dress", "Elegant midi dress with pleated details. Balances sophistication and modern style.", "", "Pleated Midi Dress", 79.5, 5 },
                    { 20, "Casual Dress", "Trendy off-shoulder design that's both flattering and stylish. Perfect for summer evenings.", "", "Off-Shoulder Dress", 64.989999999999995, 4 },
                    { 21, "Formal Dress", "Romantic dress with delicate lace details. Ideal for dates and special occasions.", "", "Lace Detail Dress", 85.0, 5 },
                    { 22, "Office Dress", "Classic shirt dress with a cinching belt. Versatile piece that can be dressed up or down.", "", "Shirt Dress with Belt", 69.989999999999995, 4 },
                    { 23, "Formal Dress", "Flattering peplum silhouette that accentuates the waist. Stylish option for various occasions.", "", "Peplum Dress", 74.5, 3 },
                    { 24, "Evening Dress", "Luxurious velvet dress for evening events. Elegant and sophisticated for special occasions.", "", "Velvet Evening Dress", 100.0, 5 },
                    { 25, "Party Dress", "Modern dress with trendy asymmetric hemline. Adds interest to a classic silhouette.", "", "Asymmetric Hem Dress", 69.989999999999995, 4 },
                    { 26, "Casual Dress", "Comfortable jersey dress with classic stripe pattern. Easy-to-wear for casual occasions.", "", "Striped Jersey Dress", 50.0, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
