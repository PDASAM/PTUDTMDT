
# CINEHUB. - Movie Store

## 1. Thông tin sinh viên

- Họ và tên: Phạm Duy Anh
- MSSV: 31241026448
- Trường: Đại học Kinh tế TP. Hồ Chí Minh (UEH)
- Học phần: Phát triển ứng dụng thương mại điện tử
- Giảng viên: TS. Nguyễn Mạnh Tuấn

## 2. Giới thiệu dự án

CineHub là website cửa hàng phim trực tuyến được xây dựng
bằng ASP.NET Core MVC. Dự án mô phỏng quy trình mua sắm
trên một website thương mại điện tử, từ xem sản phẩm,
thêm vào giỏ hàng đến xác nhận đặt hàng.

Website được xây dựng phục vụ mục đích học tập.

## 3. Công nghệ sử dụng

- ASP.NET Core MVC (.NET 10)
- C#
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- HTML5, CSS3, Bootstrap
- Session và Newtonsoft.Json
- Gmail SMTP
- Visual Studio Code
- Git và GitHub
- Somee Hosting

## 4. Chức năng chính

### Khách hàng

- Xem danh sách và chi tiết phim.
- Xem danh sách thể loại.
- Đăng ký và đăng nhập tài khoản.
- Thêm sản phẩm vào giỏ hàng.
- Cập nhật số lượng và xóa sản phẩm.
- Tự động tính tổng giá trị giỏ hàng.
- Nhập thông tin giao hàng và đặt hàng.
- Nhận email xác nhận khi SMTP được cấu hình.

### Quản trị viên

- Thêm, sửa và xóa sản phẩm.
- Quản lý thể loại phim.
- Upload và cập nhật hình ảnh.
- Kiểm soát quyền quản lý danh mục sản phẩm.

## 5. Cấu trúc thư mục

- SourceCode/: Mã nguồn dự án ASP.NET Core MVC.
- Report/: Báo cáo kết quả thực hiện.
- Report/images/: Ảnh minh chứng.
- README.md: Tài liệu giới thiệu và hướng dẫn.
- .gitignore: Quy định loại trừ file không cần thiết.

## 6. Hướng dẫn chạy dự án

Yêu cầu môi trường:

- .NET SDK 10.
- SQL Server.
- Visual Studio Code hoặc Visual Studio.

Di chuyển vào thư mục dự án:

    cd ASP-CORE/SourceCode/31241026448_PhamDuyAnh

Khôi phục các package:

    dotnet restore

Cấu hình User Secrets:

    dotnet user-secrets init
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<CONNECTION_STRING>"
    dotnet user-secrets set "Admin:UserId" "<ADMIN_USER_ID>"

Cập nhật cơ sở dữ liệu nếu sử dụng database mới:

    dotnet ef database update

Tạo dữ liệu sản phẩm và thể loại thông qua giao diện
quản trị sau khi đăng ký và cấu hình tài khoản Admin.

Cấu hình Gmail SMTP nếu cần gửi email:

    dotnet user-secrets set "Email:Address" "<GMAIL_ADDRESS>"
    dotnet user-secrets set "Email:AppPassword" "<APP_PASSWORD>"

Build và chạy ứng dụng:

    dotnet build
    dotnet run --launch-profile https

Truy cập địa chỉ localhost được hiển thị trong Terminal.

## 7. Triển khai website

Website được triển khai trên Somee Hosting.

URL: https://cinehub31241026448.somee.com

Bản Release được tối ưu cho Windows nhằm giảm dung lượng
triển khai và đáp ứng giới hạn của gói hosting miễn phí.

    dotnet publish -c Release -r win-x86 --self-contained false -o ./publish

Chức năng gửi email đã được kiểm thử trên localhost.
Cấu hình Gmail SMTP không được công khai trên hosting.

## 8. Bảo mật

Thông tin kết nối SQL Server và Gmail App Password
không được lưu trực tiếp trong mã nguồn công khai.

Dự án sử dụng User Secrets trong môi trường phát triển
và cấu hình riêng trong môi trường hosting.

Các chức năng quản lý danh mục được giới hạn theo
chính sách phân quyền ManageCatalog.

## 9. Báo cáo

Báo cáo kết quả thực hiện và ảnh minh chứng được lưu
trong thư mục Report.

## 10. Repository

https://github.com/PDASAM/ecommerce-ui-improvement
