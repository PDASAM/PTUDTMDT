
/* Exercise 8.7 - Arrays */

// Tạo mảng các ngày trong tuần
var daysOfWeek = new Array("Mon", "Tues", "Wed", "Thur", "Fri");

// Thêm thứ Bảy vào cuối mảng
daysOfWeek.push("Sat");

// Thêm Chủ nhật vào đầu mảng
daysOfWeek.unshift("Sun");

// Không in mảng trực tiếp nữa
// document.write(daysOfWeek + "<br/>");

// Bắt đầu tạo bảng
document.write("<table border='1'>");

// Tạo hàng tiêu đề
document.write("<tr>");

for (var i = 0; i < daysOfWeek.length; i++) {
    var day;

    if (daysOfWeek[i].length < 4) {
        day = daysOfWeek[i];
    } else {
        day = "<em>" + daysOfWeek[i] + "</em>";
    }

    document.write("<th>" + day + "</th>");
}

document.write("</tr>");

// Tạo lịch 30 ngày, bắt đầu vào Chủ nhật
for (var date = 1; date <= 30; date++) {

    // Mở hàng mới vào mỗi Chủ nhật
    if ((date - 1) % 7 === 0) {
        document.write("<tr>");
    }

    // In số ngày vào ô
    document.write("<td>" + date + "</td>");

    // Kết thúc hàng vào thứ Bảy
    if (date % 7 === 0) {
        document.write("</tr>");
    }
}

// Thêm 5 ô trống sau ngày 30
for (var empty = 0; empty < 5; empty++) {
    document.write("<td></td>");
}

// Đóng hàng cuối cùng
document.write("</tr>");

// Kết thúc bảng
document.write("</table>");
