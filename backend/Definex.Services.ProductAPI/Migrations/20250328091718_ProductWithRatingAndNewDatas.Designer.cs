﻿// <auto-generated />
using Definex.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Definex.Services.ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250328091718_ProductWithRatingAndNewDatas")]
    partial class ProductWithRatingAndNewDatas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DefineX.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Casual Dress",
                            Description = "Light and breezy summer dress with beautiful floral pattern. Perfect for casual outings and beach days.",
                            ImageUrl = "",
                            Name = "Floral Summer Dress",
                            Price = 50.0,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Evening Dress",
                            Description = "Sophisticated evening gown with delicate embellishments. Ideal for formal events and special occasions.",
                            ImageUrl = "",
                            Name = "Elegant Evening Gown",
                            Price = 130.0,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Office Dress",
                            Description = "Professional and stylish pencil dress for workplace environments. Features a classic cut and comfortable fabric.",
                            ImageUrl = "",
                            Name = "Business Pencil Dress",
                            Price = 79.5,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "Casual Dress",
                            Description = "Flowing maxi dress with bohemian patterns and comfortable fit. Perfect for summer festivals and casual wear.",
                            ImageUrl = "",
                            Name = "Bohemian Maxi Dress",
                            Price = 59.990000000000002,
                            Rating = 3
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryName = "Party Dress",
                            Description = "Stylish cocktail dress with modern design. Suitable for parties and semi-formal events.",
                            ImageUrl = "",
                            Name = "Cocktail Party Dress",
                            Price = 89.989999999999995,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryName = "Vintage Dress",
                            Description = "Retro-inspired dress with classic polka dot pattern. Features a flattering A-line silhouette.",
                            ImageUrl = "",
                            Name = "Vintage Polka Dot Dress",
                            Price = 65.989999999999995,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryName = "Formal Dress",
                            Description = "Elegant dress perfect for wedding guests. Balanced between formal and festive for special celebrations.",
                            ImageUrl = "",
                            Name = "Wedding Guest Dress",
                            Price = 100.0,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryName = "Casual Dress",
                            Description = "Classic little black dress that's versatile for multiple occasions. A wardrobe essential.",
                            ImageUrl = "",
                            Name = "Little Black Dress",
                            Price = 69.989999999999995,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryName = "Casual Dress",
                            Description = "Flattering wrap dress design that suits various body types. Comfortable and stylish for everyday wear.",
                            ImageUrl = "",
                            Name = "Wrap Dress",
                            Price = 54.990000000000002,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryName = "Summer Dress",
                            Description = "Practical and cute sundress featuring convenient pockets. Perfect for summer days.",
                            ImageUrl = "",
                            Name = "Sundress with Pockets",
                            Price = 45.5,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryName = "Casual Dress",
                            Description = "Casual denim shirt dress that combines comfort and style. Great for everyday casual looks.",
                            ImageUrl = "",
                            Name = "Denim Shirt Dress",
                            Price = 59.990000000000002,
                            Rating = 3
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryName = "Winter Dress",
                            Description = "Warm and cozy sweater dress for cold weather. Features a comfortable fit and high-quality knit fabric.",
                            ImageUrl = "",
                            Name = "Winter Sweater Dress",
                            Price = 75.0,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryName = "Casual Dress",
                            Description = "Classic fit and flare silhouette that flatters many body types. Versatile for various occasions.",
                            ImageUrl = "",
                            Name = "Fit and Flare Dress",
                            Price = 68.5,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryName = "Party Dress",
                            Description = "Eye-catching sequin dress that makes a statement at parties and special events.",
                            ImageUrl = "",
                            Name = "Sequin Party Dress",
                            Price = 119.98999999999999,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryName = "Summer Dress",
                            Description = "Breathable linen dress perfect for hot summer days. Comfortable and effortlessly stylish.",
                            ImageUrl = "",
                            Name = "Linen Summer Dress",
                            Price = 65.0,
                            Rating = 3
                        },
                        new
                        {
                            ProductId = 16,
                            CategoryName = "Party Dress",
                            Description = "Figure-hugging bodycon dress that accentuates curves. Great for nights out and social events.",
                            ImageUrl = "",
                            Name = "Bodycon Dress",
                            Price = 59.990000000000002,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 17,
                            CategoryName = "Casual Dress",
                            Description = "Casual and comfortable t-shirt dress. The perfect throw-on-and-go piece for busy days.",
                            ImageUrl = "",
                            Name = "T-Shirt Dress",
                            Price = 40.0,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 18,
                            CategoryName = "Summer Dress",
                            Description = "Stylish halter neck design that highlights shoulders. Great for summer events and parties.",
                            ImageUrl = "",
                            Name = "Halter Neck Dress",
                            Price = 69.989999999999995,
                            Rating = 3
                        },
                        new
                        {
                            ProductId = 19,
                            CategoryName = "Formal Dress",
                            Description = "Elegant midi dress with pleated details. Balances sophistication and modern style.",
                            ImageUrl = "",
                            Name = "Pleated Midi Dress",
                            Price = 79.5,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 20,
                            CategoryName = "Casual Dress",
                            Description = "Trendy off-shoulder design that's both flattering and stylish. Perfect for summer evenings.",
                            ImageUrl = "",
                            Name = "Off-Shoulder Dress",
                            Price = 64.989999999999995,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 21,
                            CategoryName = "Formal Dress",
                            Description = "Romantic dress with delicate lace details. Ideal for dates and special occasions.",
                            ImageUrl = "",
                            Name = "Lace Detail Dress",
                            Price = 85.0,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 22,
                            CategoryName = "Office Dress",
                            Description = "Classic shirt dress with a cinching belt. Versatile piece that can be dressed up or down.",
                            ImageUrl = "",
                            Name = "Shirt Dress with Belt",
                            Price = 69.989999999999995,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 23,
                            CategoryName = "Formal Dress",
                            Description = "Flattering peplum silhouette that accentuates the waist. Stylish option for various occasions.",
                            ImageUrl = "",
                            Name = "Peplum Dress",
                            Price = 74.5,
                            Rating = 3
                        },
                        new
                        {
                            ProductId = 24,
                            CategoryName = "Evening Dress",
                            Description = "Luxurious velvet dress for evening events. Elegant and sophisticated for special occasions.",
                            ImageUrl = "",
                            Name = "Velvet Evening Dress",
                            Price = 100.0,
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 25,
                            CategoryName = "Party Dress",
                            Description = "Modern dress with trendy asymmetric hemline. Adds interest to a classic silhouette.",
                            ImageUrl = "",
                            Name = "Asymmetric Hem Dress",
                            Price = 69.989999999999995,
                            Rating = 4
                        },
                        new
                        {
                            ProductId = 26,
                            CategoryName = "Casual Dress",
                            Description = "Comfortable jersey dress with classic stripe pattern. Easy-to-wear for casual occasions.",
                            ImageUrl = "",
                            Name = "Striped Jersey Dress",
                            Price = 50.0,
                            Rating = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
