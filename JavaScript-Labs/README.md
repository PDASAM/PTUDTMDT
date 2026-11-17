# JavaScript Labs – Phát triển ứng dụng TMĐT

**Sinh viên:** Phạm Duy Anh  
**MSSV:** 31241026448  
**Lớp học phần:** 26C1INF50903101  
**Giảng viên:** TS. Nguyễn Mạnh Tuấn  
**Trường:** Đại học Kinh tế Thành phố Hồ Chí Minh (UEH)

## Mục tiêu

Thực hiện ba bài thực hành JavaScript nhằm nắm vững nền tảng ngôn ngữ, thao tác DOM, xử lý sự kiện và biểu mẫu, đồng thời sử dụng jQuery và AJAX để bổ sung tính tương tác và truy xuất dữ liệu trên website.

## Các bài thực hành

| Lab | Nội dung | Số Exercise | Truy cập |
| --- | --- | ---: | --- |
| 08 | JavaScript 1 – Language Foundations: String, Date, Math, Array, Function, Object và Console | 11 | [Lab 08](Lab08/) |
| 09 | JavaScript 2 – DOM and Events: DOM Selection, Events, Debugging, Forms và Validation | 8 | [Lab 09](Lab09/) |
| 10 | JavaScript 3 – jQuery: Selectors, Events, Animation, GET Requests và jqXHR | 10 | [Lab 10](Lab10/) |

**Tổng cộng: 29 Exercise.**

## Cấu trúc thư mục

```text
JavaScript-Labs/
├── index.html             # Portfolio tổng và điều hướng 3 Lab
├── css/style.css          # Giao diện portfolio
├── js/main.js             # JavaScript của portfolio
├── assets/avatar.svg      # Avatar minh họa (có thể thay bằng ảnh cá nhân)
├── Lab08/
│   ├── index.html         # Danh sách 11 Exercise
│   └── Exercise01/ ... Exercise11/
├── Lab09/
│   ├── index.html         # Danh sách 8 Exercise
│   └── Exercise01/ ... Exercise08/
├── Lab10/
│   ├── index.html         # Danh sách 10 Exercise
│   └── Exercise01/ ... Exercise10/
└── Screenshots/            # Ảnh tự chụp minh chứng, lưu cục bộ để làm báo cáo Word
```

Các thư mục Lab vẫn giữ lại các tệp HTML, CSS, JavaScript, hình ảnh và tài nguyên mẫu được cung cấp trong giáo trình.

## Truy cập website

- **GitHub Repository:** https://github.com/PDASAM/ecommerce-ui-improvement/tree/main/JavaScript-Labs
- **GitHub Pages (sau khi triển khai):** https://pdasam.github.io/ecommerce-ui-improvement/JavaScript-Labs/
- **Lab 08:** https://pdasam.github.io/ecommerce-ui-improvement/JavaScript-Labs/Lab08/
- **Lab 09:** https://pdasam.github.io/ecommerce-ui-improvement/JavaScript-Labs/Lab09/
- **Lab 10:** https://pdasam.github.io/ecommerce-ui-improvement/JavaScript-Labs/Lab10/

Mở trang portfolio và chọn Lab cần kiểm tra, sau đó nhấp vào từng Exercise. Các bài được xây dựng để chạy dưới dạng trang web tĩnh trên GitHub Pages. Bài 10.9–10.10 sử dụng Open-Meteo Geocoding API thay cho dịch vụ cũ trong tài liệu vì cần endpoint HTTPS phù hợp với GitHub Pages.

## Chạy trên máy

Mở `JavaScript-Labs/index.html` bằng trình duyệt hoặc khởi chạy bằng VS Code Live Preview. Đối với các chức năng AJAX, nên truy cập qua Live Preview hoặc GitHub Pages thay vì mở file theo `file://`.

## Minh chứng và báo cáo

Ảnh chụp phải lấy từ kết quả chạy thực tế của chính sinh viên. Sử dụng ảnh trong thư mục `Screenshots` để biên soạn báo cáo Word, theo mẫu tên `31241026448_PhamDuyAnh_JavaScript_Labs.docx`. Khi nộp bài, kiểm tra đường dẫn GitHub Pages, từng Exercise và các ảnh minh chứng trong file Word.
