// Portfolio JavaScript: cập nhật năm hiển thị.
document.addEventListener('DOMContentLoaded', function () {
  var year = document.getElementById('year');
  if (year) year.textContent = new Date().getFullYear();
});
