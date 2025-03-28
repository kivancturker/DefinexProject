using DefineX.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Definex.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dress Products
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "Floral Summer Dress",
            Price = 50.00,
            Description = "Light and breezy summer dress with beautiful floral pattern. Perfect for casual outings and beach days.",
            ImageUrl = "https://www.leonardo-carbone.com/media/image/product/409/sm/4070-herbstkleid-ava_7~3.jpg",
            CategoryName = "Casual Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 2,
            Name = "Elegant Evening Gown",
            Price = 130.00,
            Description = "Sophisticated evening gown with delicate embellishments. Ideal for formal events and special occasions.",
            ImageUrl = "https://edenmodelmanagement.com/wp-content/uploads/2019/04/alena4-300x350.jpg",
            CategoryName = "Evening Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            Name = "Business Pencil Dress",
            Price = 79.50,
            Description = "Professional and stylish pencil dress for workplace environments. Features a classic cut and comfortable fabric.",
            ImageUrl = "https://l450v.alamy.com/450v/r63fjt/spa-woman-smiling-female-model-with-perfect-skin-r63fjt.jpg",
            CategoryName = "Office Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 4,
            Name = "Bohemian Maxi Dress",
            Price = 59.99,
            Description = "Flowing maxi dress with bohemian patterns and comfortable fit. Perfect for summer festivals and casual wear.",
            ImageUrl = "https://www.neeley.tcu.edu/getmedia/b037e539-6850-4f43-8356-c9e28b07c29a/Wedeking-Shay-vert.jpg",
            CategoryName = "Casual Dress",
            Rating = 3
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 5,
            Name = "Cocktail Party Dress",
            Price = 89.99,
            Description = "Stylish cocktail dress with modern design. Suitable for parties and semi-formal events.",
            ImageUrl = "https://modafabrics.com/sites/default/files/designer/lb-2024-web.jpg",
            CategoryName = "Party Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 6,
            Name = "Vintage Polka Dot Dress",
            Price = 65.99,
            Description = "Retro-inspired dress with classic polka dot pattern. Features a flattering A-line silhouette.",
            ImageUrl = "https://www.usleathermart.com/wp-content/uploads/2024/05/Aaron-Taylor-Johnson-Leather-Jacket-1-300x350.jpg",
            CategoryName = "Vintage Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 7,
            Name = "Wedding Guest Dress",
            Price = 100.00,
            Description = "Elegant dress perfect for wedding guests. Balanced between formal and festive for special celebrations.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbm369JGVf3m0pytIVA-OVTkQ9KZCHfoqxZg&s",
            CategoryName = "Formal Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 8,
            Name = "Little Black Dress",
            Price = 69.99,
            Description = "Classic little black dress that's versatile for multiple occasions. A wardrobe essential.",
            ImageUrl = "https://m.media-amazon.com/images/I/61+M+viwIwL._AC_UY350_.jpg",
            CategoryName = "Casual Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 9,
            Name = "Wrap Dress",
            Price = 54.99,
            Description = "Flattering wrap dress design that suits various body types. Comfortable and stylish for everyday wear.",
            ImageUrl = "https://m.media-amazon.com/images/I/815YLNhC7pL._AC_UY350_.jpg",
            CategoryName = "Casual Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 10,
            Name = "Sundress with Pockets",
            Price = 45.50,
            Description = "Practical and cute sundress featuring convenient pockets. Perfect for summer days.",
            ImageUrl = "https://www.dress-desiree.com/32535-home_default/textured-red-backless-dress.jpg",
            CategoryName = "Summer Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 11,
            Name = "Denim Shirt Dress",
            Price = 59.99,
            Description = "Casual denim shirt dress that combines comfort and style. Great for everyday casual looks.",
            ImageUrl = "https://smilesfashion.com/wp-content/uploads/2023/08/DSC8700-scaled-300x350.jpg",
            CategoryName = "Casual Dress",
            Rating = 3
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 12,
            Name = "Winter Sweater Dress",
            Price = 75.00,
            Description = "Warm and cozy sweater dress for cold weather. Features a comfortable fit and high-quality knit fabric.",
            ImageUrl = "https://m.media-amazon.com/images/I/81KPlzAS++L._AC_UY350_.jpg",
            CategoryName = "Winter Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 13,
            Name = "Fit and Flare Dress",
            Price = 68.50,
            Description = "Classic fit and flare silhouette that flatters many body types. Versatile for various occasions.",
            ImageUrl = "https://hollywoodlife.com/wp-content/uploads/2018/12/models-wearing-short-dresses-vertical1.jpg?resize=300%2C350",
            CategoryName = "Casual Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 14,
            Name = "Sequin Party Dress",
            Price = 119.99,
            Description = "Eye-catching sequin dress that makes a statement at parties and special events.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6uWAAPRp9xQR2PdWh0MYSCSzrLytD5mCQJQ&s",
            CategoryName = "Party Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 15,
            Name = "Linen Summer Dress",
            Price = 65.00,
            Description = "Breathable linen dress perfect for hot summer days. Comfortable and effortlessly stylish.",
            ImageUrl = "https://smilesfashion.com/wp-content/uploads/2024/11/790EF673-FE2B-4700-A11D-EDB73B8C8270-300x350.jpg",
            CategoryName = "Summer Dress",
            Rating = 3
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 16,
            Name = "Bodycon Dress",
            Price = 59.99,
            Description = "Figure-hugging bodycon dress that accentuates curves. Great for nights out and social events.",
            ImageUrl = "https://www.leonardo-carbone.com/media/image/product/7430/sm/wikinger-ueberkleid-aus-wolle-aila-rot~9.jpg",
            CategoryName = "Party Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 17,
            Name = "T-Shirt Dress",
            Price = 40.00,
            Description = "Casual and comfortable t-shirt dress. The perfect throw-on-and-go piece for busy days.",
            ImageUrl = "https://michdulce.com/wp-content/uploads/2024/03/WebRes145_V0929-300x350.jpg",
            CategoryName = "Casual Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 18,
            Name = "Halter Neck Dress",
            Price = 69.99,
            Description = "Stylish halter neck design that highlights shoulders. Great for summer events and parties.",
            ImageUrl = "https://hollywoodlife.com/wp-content/uploads/2023/01/miss-universe-evening-gowns-v2-vertical.jpg?resize=300%2C350",
            CategoryName = "Summer Dress",
            Rating = 3
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 19,
            Name = "Pleated Midi Dress",
            Price = 79.50,
            Description = "Elegant midi dress with pleated details. Balances sophistication and modern style.",
            ImageUrl = "https://static.wixstatic.com/media/b8269e_6db52e3f9a7c430d819b423bbdfe206a~mv2.jpg/v1/fill/w_300,h_350,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/b8269e_6db52e3f9a7c430d819b423bbdfe206a~mv2.jpg",
            CategoryName = "Formal Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 20,
            Name = "Off-Shoulder Dress",
            Price = 64.99,
            Description = "Trendy off-shoulder design that's both flattering and stylish. Perfect for summer evenings.",
            ImageUrl = "https://coemi-lingerie.com/3869-home_default/long-satin-nightdress-with-thin-straps.jpg",
            CategoryName = "Casual Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 21,
            Name = "Lace Detail Dress",
            Price = 85.00,
            Description = "Romantic dress with delicate lace details. Ideal for dates and special occasions.",
            ImageUrl = "https://sc04.alicdn.com/kf/U4bb1b51803df4c92bdf5afc0038608bbB.jpg_350x350.jpg",
            CategoryName = "Formal Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 22,
            Name = "Shirt Dress with Belt",
            Price = 69.99,
            Description = "Classic shirt dress with a cinching belt. Versatile piece that can be dressed up or down.",
            ImageUrl = "https://www.evansville.edu/aces-of-ue/images/spotlight-photos/rebecca-crow.jpg",
            CategoryName = "Office Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 23,
            Name = "Peplum Dress",
            Price = 74.50,
            Description = "Flattering peplum silhouette that accentuates the waist. Stylish option for various occasions.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdPsdXIJ9H6rHaKQW7aFDgyMkuFyFOpyZB8w&s",
            CategoryName = "Formal Dress",
            Rating = 3
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 24,
            Name = "Velvet Evening Dress",
            Price = 100.00,
            Description = "Luxurious velvet dress for evening events. Elegant and sophisticated for special occasions.",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQrT4bn67wiDMBrQbmeZ65NdmMFzkNO6Ocp8A&s",
            CategoryName = "Evening Dress",
            Rating = 5
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 25,
            Name = "Asymmetric Hem Dress",
            Price = 69.99,
            Description = "Modern dress with trendy asymmetric hemline. Adds interest to a classic silhouette.",
            ImageUrl = "https://static.wixstatic.com/media/b8269e_7a2336c5ea1b445bab1042b0202baeb5~mv2.jpg/v1/fill/w_300,h_350,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/b8269e_7a2336c5ea1b445bab1042b0202baeb5~mv2.jpg",
            CategoryName = "Party Dress",
            Rating = 4
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 26,
            Name = "Striped Jersey Dress",
            Price = 50.00,
            Description = "Comfortable jersey dress with classic stripe pattern. Easy-to-wear for casual occasions.",
            ImageUrl = "https://compass.ucf.edu/wp-content/uploads/sites/8/2021/04/taylor-profilepic-e1617818787718-300x350.jpg",
            CategoryName = "Casual Dress",
            Rating = 2
        });
    }
}