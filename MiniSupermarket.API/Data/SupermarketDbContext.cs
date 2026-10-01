/*
 *  ho ten sinh vien: Nguyen Van Teo
 *  ma sinh vien: 123456789
 *  Ngay tao: 15/09/2026 
 *  mo ta: thuc the San Pham, tuong ung voiw table Products tong CSDL
 */
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MiniSupermarket.API.Data
{
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nạp sẵn 5 danh mục ban đầu vào SQL Server ngay khi tạo bảng
            modelBuilder.Entity<Category>().HasData(
new Category { CategoryId = 2, CategoryName = "Rau củ hữu cơ", Description = "Rau xanh, củ quả đạt chuẩn VietGAP, Organic" },
new Category { CategoryId = 3, CategoryName = "Trái cây sạch nội địa", Description = "Trái cây theo mùa canh tác tự nhiên, không hóa chất bảo quản" },
new Category { CategoryId = 4, CategoryName = "Trái cây nhập khẩu chuẩn GlobalGAP", Description = "Táo, nho, cherry có chứng nhận an toàn quốc tế" },
new Category { CategoryId = 5, CategoryName = "Thịt tươi sạch", Description = "Thịt heo, bò, gà thả vườn không kháng sinh và chất tạo nạc" },
new Category { CategoryId = 6, CategoryName = "Thủy hải sản đánh bắt tự nhiên", Description = "Cá sông, tôm cua biển tươi sống cấp đông nhanh" },
new Category { CategoryId = 7, CategoryName = "Gạo & Ngũ cốc nguyên cám", Description = "Gạo lứt, yến mạch, hạt diêm mạch canh tác hữu cơ" },
new Category { CategoryId = 8, CategoryName = "Hạt dinh dưỡng organic", Description = "Hạnh nhân, óc chó, hạt điều sấy mộc không phụ gia" },
new Category { CategoryId = 9, CategoryName = "Gia vị & Nước mắm truyền thống", Description = "Muối hầm, đường mía thô, mắm cá cơm ủ chượp tự nhiên" },
new Category { CategoryId = 10, CategoryName = "Trứng gia cầm chăn thả", Description = "Trứng gà ta, trứng vịt thả đồng giàu Omega-3" },
new Category { CategoryId = 11, CategoryName = "Sữa & Chế phẩm từ sữa hữu cơ", Description = "Sữa tươi thanh trùng Organic, sữa chua lên men tự nhiên" },
new Category { CategoryId = 12, CategoryName = "Sữa hạt thuần chay", Description = "Sữa hạt điều, đậu nành không đường và chất bảo quản" },
new Category { CategoryId = 13, CategoryName = "Nấm tươi & Nấm khô dược liệu", Description = "Nấm đùi gà, đông cô, nấm mối nuôi trồng phòng sạch" },
new Category { CategoryId = 14, CategoryName = "Đồ uống lên men & Trà thảo mộc", Description = "Kombucha, giấm táo lên men tự nhiên, trà hoa cúc sấy lạnh" },
new Category { CategoryId = 15, CategoryName = "Thực phẩm thực dưỡng chế biến sẵn", Description = "Đậu phụ tươi non-GMO, tương miso, tương tamari ủ lâu năm" },
new Category { CategoryId = 16, CategoryName = "Dầu ăn thực vật nguyên chất", Description = "Dầu ô liu extra virgin, dầu mè, dầu phộng ép lạnh" }
            );
            ///
            // 2. Nạp sẵn các sản phẩm mẫu vào bảng Products (Tham chiếu đúng CategoryId 1 -> 5)
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Barcode = "893456789001",
                    ProductName = "Snack Khoai Tây O'Star Gói 60g",
                    Price = 12500m,
                    StockQuantity = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Barcode = "893456789002",
                    ProductName = "Bánh Quy Bơ Danisa Hộp Thiếc 454g",
                    Price = 135000m,
                    StockQuantity = 40,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Barcode = "893456789003",
                    ProductName = "Nước Ngọt Coca Cola Lon 320ml",
                    Price = 10000m,
                    StockQuantity = 320,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Barcode = "893456789004",
                    ProductName = "Nước Khoáng Lavie Chai 500ml",
                    Price = 6000m,
                    StockQuantity = 200,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    Barcode = "893456789005",
                    ProductName = "Sữa Tươi Tiệt Trùng Vinamilk 1L",
                    Price = 34500m,
                    StockQuantity = 85,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 6,
                    Barcode = "893456789006",
                    ProductName = "Mì Tôm Hảo Hảo Chua Cay Gói 75g",
                    Price = 4500m,
                    StockQuantity = 500,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 7,
                    Barcode = "893456789007",
                    ProductName = "Dầu Ăn Simply Nguyên Chất Can 2L",
                    Price = 125000m,
                    StockQuantity = 45,
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 8,
                    Barcode = "893456789008",
                    ProductName = "Nước Mắm Nam Ngư Chai 900ml",
                    Price = 30000m,
                    StockQuantity = 90,
                    CategoryId = 5
                }
            );
        }
    }
        
}
