# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
> **Buổi thực hành:** Buổi 1 - Xây dựng Web API quản lý danh mục và kết nối WinForms Client (CRUD)

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án được xây dựng theo mô hình phân tầng hiện đại, tách biệt hoàn toàn giữa Backend và Frontend:
* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API chịu trách nhiệm xử lý logic nghiệp vụ, quản lý dữ liệu và cung cấp các RESTful API chuẩn hóa.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms đóng vai trò là máy trạm POS tại quầy, sử dụng `HttpClient` để gọi dữ liệu từ API qua mạng và hiển thị trực quan lên `DataGridView`.

---

## 🛠️ 2. Công nghệ Sử dụng
* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API, Controllers, In-Memory Data, LINQ
* **Frontend:** Windows Forms (.NET 8.0), `System.Net.Http.Json`
* **Công cụ kiểm thử:** Swagger UI

---

## 📂 3. Cấu trúc Solution
```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/          # Dự án Web API (Backend)
│   ├── Controllers/              # Chứa CategoriesController (CRUD & Search)
│   ├── Models/                   # Chứa lớp thực thể Category.cs
│   └── Program.cs                # Cấu hình dịch vụ và Middleware
│
└── MiniSupermarket.WinForms/     # Dự án Windows Forms (Frontend Client)
    └── FormCategoryManagement.cs # Giao diện quản lý danh mục CRUD


🚀 4. Hướng dẫn Chạy và Kiểm thử Dự án
Bước 1: Chạy phía Backend (Web API)
Mở Solution bằng Visual Studio 2022.


Nhấp chuột phải vào project MiniSupermarket.API chọn Set as Startup Project.


Nhấn F5 để chạy. Trình duyệt sẽ tự động mở giao diện Swagger UI để kiểm tra các phương thức GET, POST, PUT, DELETE.


Bước 2: Chạy phía Frontend (WinForms Client)
Đảm bảo cổng (Port) trong ApiClientService hoặc HttpClient của WinForms khớp với cổng https://localhost:XXXXX của Web API đang chạy.

Nhấp chuột phải vào project MiniSupermarket.WinForms chọn Debug -> Start new instance.

Thử nghiệm các chức năng: Tải danh sách, Thêm mới, Sửa, Xóa và Tìm kiếm nhóm hàng.

👨‍💻 5. Tác giả
Họ tên sinh viên: Nguyễn Văn Tèo


Mã sinh viên: 123456789


Lớp học phần: CQQ2411C
=======================================================================================================================
BUỔI 2: BẢO MẬT & PHÂN QUYỀN JWT CHO WEB API
1. MỤC TIÊU BUỔI 2
Lý thuyết: Nắm vững cơ chế xác thực không trạng thái (Stateless Authentication) với JWT (JSON Web Token), hiểu cách sử dụng
Data Annotations để xác thực dữ liệu đầu vào và ứng dụng Action Filters để tùy biến vòng đời Request.

Thực hành: Tích hợp AuthController cấp phát token vào dự án MiniSupermarket.API, đồng thời cập nhật WinForms Client để quản
lý phiên đăng nhập và đính kèm Bearer Token khi gọi API.


=======================================================================================================================
BUỔI 3: TÍCH HỢP SQL SERVER VÀ ENTITY FRAMEWORK CORE CODE-FIRST
1. MỤC TIÊU VÀ BỐI CẢNH THỰC TẾ
Mục tiêu:


Thay thế hoàn toàn cơ chế lưu tạm trên RAM (In-Memory) ở Buổi 1 và Buổi 2 bằng cơ sở dữ liệu quan hệ Microsoft SQL Server.

Làm chủ kỹ thuật Entity Framework Core (EF Core) Code-First: Viết lớp C# trước rồi tự động sinh bảng trong CSDL.

Nắm vững các lệnh EF Core Migrations và truy vấn dữ liệu bất đồng bộ bằng LINQ (async/await).

Bối cảnh thực tế đồ án: Khi nhân viên thu ngân thêm hoặc sửa nhóm hàng trên phần mềm WinForms, dữ liệu phải được lưu trữ vĩnh viễn trong CSDL MiniSupermarketDb của SQL Server, đảm bảo tắt máy hoặc khởi động lại API dữ liệu vẫn còn nguyên vẹn.

