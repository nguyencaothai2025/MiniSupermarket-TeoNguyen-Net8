# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Nền tảng:** .NET 8.0 / C#  
> **Kiến trúc:** Client - Server (RESTful Web API & WinForms Desktop App)  
> **Tác giả:** Nguyễn Văn Tèo | **MSSV:** 123456789 | **Lớp:** CQQ2411C  

---

## 🏗️ 1. MÔ HÌNH KIẾN TRÚC HỆ THỐNG
Dự án được thiết kế theo mô hình phân tầng hướng dịch vụ (SOA - Multi-tier Architecture) nhằm tách biệt giữa tầng xử lý nghiệp vụ trung tâm và tầng giao diện người dùng:
- **`MiniSupermarket.API` (Backend Server):**
  - Cung cấp dịch vụ dữ liệu chuẩn hóa theo giao thức RESTful qua JSON.
  - Tích hợp Middleware Pipeline, cơ chế kiểm tra tính hợp lệ dữ liệu (Model Validation) và cơ chế phân quyền bảo mật không trạng thái (Stateless JWT Authentication).
  - Tương tác dữ liệu linh hoạt: kết hợp **Entity Framework Core Code-First** (quản lý thực thể, quan hệ bảng) và **ADO.NET thuần** (xử lý Stored Procedure tốc độ cao và Transaction giao dịch ACID).
- **`MiniSupermarket.WinForms` (Frontend Desktop Client):**
  - Đóng vai trò máy trạm thu ngân POS và quản trị siêu thị.
  - Kết nối với Backend thông qua `HttpClient` và thư viện giải tuần tự `System.Net.Http.Json`.
  - Tự động đính kèm `Bearer Token` vào HTTP Header của mỗi request sau khi xác thực đăng nhập thành công.

---

## 🛠️ 2. CÔNG NGHỆ & THƯ VIỆN SỬ DỤNG
- **Nền tảng & Ngôn ngữ:** .NET 8.0 (LTS), C# 12.
- **Backend Packages:**
  - `Swashbuckle.AspNetCore` (OpenAPI / Swagger UI)
  - `Microsoft.AspNetCore.Authentication.JwtBearer` (JWT Token Handling)
  - `Microsoft.EntityFrameworkCore.SqlServer` & `Microsoft.EntityFrameworkCore.Tools` (EF Core ORM)
  - `Microsoft.Data.SqlClient` (ADO.NET nâng cao)
- **Frontend Packages:**
  - `System.Net.Http.Json`
- **Hệ quản trị CSDL:** Microsoft SQL Server (CSDL: `MiniSupermarketDb`).

---

## 📂 3. CẤU TRÚC SOLUTION
```text
MiniSupermarketSolution/
│
├── MiniSupermarket.API/                   # Dự án Backend (ASP.NET Core Web API)
│   ├── Controllers/                       # Xử lý Endpoint nghiệp vụ
│   │   ├── AuthController.cs              # Cấp phát JWT Token (Admin, Cashier)
│   │   ├── CategoriesController.cs        # Quản lý nhóm hàng (CRUD & Search)
│   │   ├── ProductsController.cs          # Quản lý sản phẩm, tồn kho
│   │   └── ReportsController.cs           # Thống kê báo cáo doanh thu (ADO.NET)
│   ├── Data/                              # Tầng dữ liệu & CSDL
│   │   ├── MiniSupermarketDbContext.cs    # EF Core DbContext & Fluent API
│   │   └── Migrations/                    # Lịch sử phiên bản cấu trúc CSDL
│   ├── Models/                            # Thực thể CSDL (Category, Product, User, Order...)
│   ├── DTOs/                              # Data Transfer Objects (Login, Register, Report...)
│   ├── appsettings.json                   # Chuỗi kết nối ConnectionStrings & JWT Key
│   └── Program.cs                         # Cấu hình DI Container, Middleware Pipeline
│
└── MiniSupermarket.WinForms/              # Dự án Frontend (Windows Forms Client)
    ├── Services/                          # Lớp tiện ích kết nối mạng
    │   └── ApiClientService.cs            # HttpClient wrapper tự gắn JWT Bearer Token
    ├── FormLogin.cs                       # Giao diện đăng nhập hệ thống
    ├── FormCategoryManagement.cs          # Quản lý danh mục nhóm hàng
    └── FormProductManagement.cs           # Quản lý hàng hóa, tìm kiếm & phân trang

```

---

## 📚 4. CHI TIẾT CÁC BUỔI THỰC HÀNH

### 🟢 BUỔI 1: KHỞI TẠO WEB API VÀ KẾT NỐI WINFORMS CLIENT (CRUD IN-MEMORY)

* **Mục tiêu:**
* Khởi tạo dự án ASP.NET Core Web API theo mô hình ControllerBase và Route Attribute.
* Hiểu cơ chế định dạng chuỗi JSON và quy chuẩn các động từ HTTP (GET, POST, PUT, DELETE).
* Xây dựng máy trạm WinForms Client sử dụng `HttpClient` để tiêu thụ dữ liệu qua mạng.


* **Nội dung thực hiện:**
* **Backend (`MiniSupermarket.API`):**
* Định nghĩa mô hình thực thể `Category.cs` (`CategoryId`, `CategoryName`, `Description`).
* Viết `CategoriesController` với danh sách tĩnh `static List<Category>` (In-Memory) nạp sẵn 15 dòng dữ liệu danh mục ban đầu.
* Hiện thực đầy đủ các Action: `GetAll`, `GetById`, `Create`, `Update`, `Delete` và lọc tìm kiếm danh mục qua Query String `[HttpGet("search")]`.
* Kích hoạt và kiểm thử trực quan trên Swagger UI.


* **Frontend (`MiniSupermarket.WinForms`):**
* Cài đặt gói `System.Net.Http.Json`.
* Thiết kế màn hình `FormCategoryManagement`: bảng `DataGridView`, các ô nhập liệu và các nút bấm chức năng.
* Gọi API qua các hàm `GetFromJsonAsync`, `PostAsJsonAsync`, `PutAsJsonAsync`, `DeleteAsync`.





---

### 🟡 BUỔI 2: BẢO MẬT & PHÂN QUYỀN STATELESS AUTHENTICATION VỚI JWT

* **Mục tiêu:**
* Nắm vững cơ chế xác thực không trạng thái (Stateless Authentication) bằng JSON Web Token (JWT).
* Sử dụng Data Annotations để ràng buộc và kiểm tra tính hợp lệ của dữ liệu đầu vào (`ModelState.IsValid`).
* Triển khai bộ lọc (Filters/Attributes) để kiểm soát quyền hạn truy cập theo vai trò (`Roles`).


* **Nội dung thực hiện:**
* **Backend (`MiniSupermarket.API`):**
* Cài đặt gói `Microsoft.AspNetCore.Authentication.JwtBearer`.
* Cấu hình JWT trong `appsettings.json` (SecretKey, Issuer, Audience) và đăng ký dịch vụ `AddAuthentication`, `AddJwtBearer` trong `Program.cs`.
* Xây dựng `AuthController` với chức năng đăng nhập: kiểm tra tài khoản, tạo `Claims` (UserId, Username, Role) và phát hành chuỗi mã hóa Token.
* Gắn các thuộc tính bảo vệ `[Authorize]` trên Controller và phân quyền chi tiết: `[Authorize(Roles = "Admin")]` cho thao tác Sửa/Xóa và cho phép `Cashier` xem danh sách.
* Tùy biến Swagger UI hỗ trợ nút **Authorize** để kiểm thử với Bearer Token.


* **Frontend (`MiniSupermarket.WinForms`):**
* Xây dựng màn hình đăng nhập `FormLogin.cs`.
* Quản lý phiên làm việc thông qua việc lưu JWT Token vào một lớp biến tĩnh toàn cục (`AuthSession`).
* Thiết lập `HttpClient.DefaultRequestHeaders.Authorization` tự động gửi kèm Bearer Token trong mỗi thao tác để tránh lỗi HTTP 401 Unauthorized / 403 Forbidden.





---

### 🔵 BUỔI 3: TÍCH HỢP MICROSOFT SQL SERVER VÀ EF CORE CODE-FIRST

* **Mục tiêu:**
* Chuyển đổi toàn bộ cơ chế lưu trữ tạm trên RAM (In-Memory) sang lưu trữ lâu dài trên CSDL quan hệ Microsoft SQL Server.
* Làm chủ kỹ thuật Entity Framework Core Code-First: xây dựng Entity Model và cấu hình `DbContext`.
* Quản lý tiến hóa cấu trúc bảng thông qua lệnh Migrations và áp dụng truy vấn bất đồng bộ LINQ (`async`/`await`).


* **Nội dung thực hiện:**
* **Cài đặt thư viện:** Cài đặt `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools` và `Microsoft.EntityFrameworkCore.Design`.
* **Cấu hình CSDL:**
* Khai báo chuỗi kết nối kết nối `DefaultConnection` tới SQL Server trong `appsettings.json`.
* Xây dựng lớp ngữ cảnh `MiniSupermarketDbContext` kế thừa `DbContext`, khai báo tập thực thể `DbSet<Category>`.
* Cấu hình hạt giống dữ liệu ban đầu (Data Seeding) trong phương thức `OnModelCreating`.
* Đăng ký `DbContext` vào DI Container trong `Program.cs` với vòng đời `Scoped`.


* **Thực thi Migrations:**
* Chạy lệnh `Add-Migration InitialCreate` để tạo snapshot cấu trúc bảng.
* Chạy lệnh `Update-Database` để khởi tạo tự động cơ sở dữ liệu `MiniSupermarketDb` trên SQL Server.


* **Nâng cấp CategoriesController:**
* Tiêm phụ thuộc `MiniSupermarketDbContext` qua Constructor.
* Thay thế toàn bộ thao tác danh sách tĩnh bằng các hàm EF Core bất đồng bộ: `ToListAsync()`, `FindAsync()`, `AddAsync()`, `SaveChangesAsync()`.
* Tối ưu hóa truy vấn chỉ đọc với `AsNoTracking()`.





---

### 🟣 BUỔI 4: ADO.NET NÂNG CAO, BÁO CÁO THỐNG KÊ & GIAO DỊCH POS TRANSACTION (ACID)

* **Mục tiêu:**
* Hiểu rõ kiến trúc giao tiếp cấp thấp ADO.NET, kết hợp linh hoạt giữa ORM (EF Core) và SQL thuần để tối ưu hiệu năng.
* Sử dụng `SqlDataReader` theo luồng một chiều (Forward-Only) để xuất báo cáo doanh thu với tốc độ cao và tối ưu bộ nhớ RAM.
* Thực thi thủ tục lưu trữ (**Stored Procedure**) có tham số hóa bằng `SqlParameter` nhằm loại bỏ triệt để nguy cơ tấn công SQL Injection.
* Kiểm soát an toàn nghiệp vụ bán lẻ và thanh toán quầy thu ngân (POS Checkout) bằng đối tượng `SqlTransaction` tuân thủ nguyên lý giao dịch **ACID** (Commit/Rollback).


* **Nội dung thực hiện:**
* **Thủ tục lưu trữ SQL Server:**
* Viết Stored Procedure `sp_GetRevenueByCashier` trên SQL Server tổng hợp doanh thu theo từng nhân viên thu ngân (`GROUP BY CashierUsername`, tính tổng `FinalAmount` và `RewardPoints`).


* **API Thống kê Doanh thu (`ReportsController.cs`):**
* Sử dụng `SqlConnection` và `SqlCommand` với thuộc tính `CommandType = CommandType.StoredProcedure`.
* Đọc kết quả cực nhanh thông qua `SqlDataReader` và ánh xạ thành danh sách DTO nhẹ trả về JSON cho phía quản trị.


* **Xử lý Giao dịch Thanh toán Quầy POS (`SqlTransaction`):**
* Xây dựng API Checkout tiếp nhận đơn hàng gồm nhiều chi tiết món hàng (`Order` và `OrderDetails`).
* Khởi tạo giao dịch bằng `transaction = connection.BeginTransaction()`.
* Thực thi tuần tự các bước: (1) Kiểm tra số lượng tồn kho của mặt hàng, (2) Tạo hóa đơn `Orders`, (3) Thêm danh sách mặt hàng vào `OrderDetails`, (4) Trừ tồn kho trong bảng `Products`, (5) Cộng điểm tích lũy cho `Customers`.
* Áp dụng khối lệnh `try...catch`: Gọi `transaction.Commit()` khi toàn bộ quá trình thành công; tự động gọi `transaction.Rollback()` nếu có bất kỳ bước nào gặp lỗi (hết hàng, đứt kết nối mạng), bảo đảm số liệu tồn kho và doanh thu không bị sai lệch.





---

## 🚀 5. HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY DỰ ÁN

### Yêu cầu tiên quyết:

* Hệ điều hành: Windows 10/11.
* Môi trường phát triển: **Visual Studio 2022** (bản 17.8 trở lên) có cài gói workload *.NET Desktop Development* và *ASP.NET and web development*.
* Cơ sở dữ liệu: **Microsoft SQL Server** (bản 2019/2022 hoặc SQL Server Express) kèm **SSMS**.

### Bước 1: Thiết lập Cơ sở dữ liệu

1. Mở file `MiniSupermarket.API/appsettings.json` và chỉnh sửa chuỗi kết nối `DefaultConnection` phù hợp với tên máy chủ SQL Server của bạn:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

```


2. Mở cửa sổ **Package Manager Console** trong Visual Studio, chọn Default project là `MiniSupermarket.API` và chạy lệnh cập nhật CSDL:
```powershell
Update-Database

```


3. Mở SSMS, mở CSDL `MiniSupermarketDb` và chạy file script tạo các Stored Procedure cần thiết (trong đó có `sp_GetRevenueByCashier`).

### Bước 2: Khởi chạy Backend Web API

1. Chuột phải vào project `MiniSupermarket.API` $\rightarrow$ Chọn **Set as Startup Project**.
2. Nhấn **F5** để khởi chạy. Trình duyệt sẽ mở giao diện Swagger UI tại địa chỉ `https://localhost:XXXX/swagger`.
3. Sử dụng API `POST /api/auth/login` để lấy JWT Token và nhấn nút **Authorize** trên Swagger để mở khóa các Endpoint có bảo mật.

### Bước 3: Khởi chạy Frontend WinForms Client

1. Kiểm tra cấu hình `BaseAddress` trong file cấu hình/lớp `ApiClientService` của project WinForms để đảm bảo trùng khớp với cổng (Port) của Web API đang hoạt động.
2. Chuột phải vào project `MiniSupermarket.WinForms` $\rightarrow$ Chọn **Debug** $\rightarrow$ **Start New Instance**.
3. Đăng nhập bằng tài khoản mẫu và tiến hành thao tác trên các giao diện quản lý danh mục, hàng hóa và quầy thu ngân.
