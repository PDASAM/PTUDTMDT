using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _31241026448_PhamDuyAnh.Data;
using _31241026448_PhamDuyAnh.Models;
using _31241026448_PhamDuyAnh.Extension;
using Microsoft.AspNetCore.Authorization;

namespace _31241026448_PhamDuyAnh.Controllers
{
    public class MoviesController : Controller
    {
        

private readonly ApplicationDbContext _context;
private readonly IWebHostEnvironment _env;
private readonly IConfiguration _config;

public MoviesController(
    ApplicationDbContext context,
    IWebHostEnvironment env,
    IConfiguration config)
{
    _context = context;
    _env = env;
    _config = config;
}


// Lưu hình ảnh vào wwwroot/images
private async Task<string> SaveImageAsync(IFormFile file)
{
    if (file == null || file.Length == 0)
        return null;

    var ext = Path.GetExtension(file.FileName)
        .ToLowerInvariant();

    if (!new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }
        .Contains(ext))
        return null;

    var folder = Path.Combine(_env.WebRootPath, "images");

    Directory.CreateDirectory(folder);

    var fileName = Guid.NewGuid().ToString("N") + ext;

    using var stream = System.IO.File.Create(
        Path.Combine(folder, fileName));

    await file.CopyToAsync(stream);

    return "/images/" + fileName;
}


        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movies.Include(m => m.GenreObj);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.GenreObj)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Policy = "ManageCatalog")]
        public IActionResult Create()
        {
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "ManageCatalog")]
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Movie movie)
{
    if (ModelState.IsValid)
    {
        movie.PicturePath =
            await SaveImageAsync(movie.PictureUpload)
            ?? "/images/no-image.jpg";

        _context.Add(movie);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    ViewData["GenreID"] = new SelectList(
        _context.Genres, "ID", "Name", movie.GenreID);

    return View(movie);
}

        // GET: Movies/Edit/5
        [Authorize(Policy = "ManageCatalog")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name", movie.GenreID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
[Authorize(Policy = "ManageCatalog")]
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Movie movie)
{
    if (id != movie.ID)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            var newPath =
                await SaveImageAsync(movie.PictureUpload);

            if (newPath != null)
                movie.PicturePath = newPath;

            else if (string.IsNullOrEmpty(movie.PicturePath))
                movie.PicturePath = "/images/no-image.jpg";

            _context.Update(movie);

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(movie.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction(nameof(Index));
    }

    ViewData["GenreID"] = new SelectList(
        _context.Genres, "ID", "Name", movie.GenreID);

    return View(movie);
}


        // GET: Movies/Delete/5
        [Authorize(Policy = "ManageCatalog")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.GenreObj)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [Authorize(Policy = "ManageCatalog")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


public ActionResult AddToCart(int id)
{
    var movie = _context.Movies
        .FirstOrDefault(x => x.ID == id);

    if (movie == null)
    {
        return RedirectToAction("Index");
    }

    var hoaDon = HttpContext.Session
        .Get<HoaDon>("HoaDon");

    var chiTietHoaDon = hoaDon.ChiTietHoaDons
        .FirstOrDefault(x => x.MaMovie == id);

    if (chiTietHoaDon == null)
    {
        chiTietHoaDon = new ChiTietHoaDon();

        chiTietHoaDon.MaMovie = id;
        chiTietHoaDon.MovieObj = movie;
        chiTietHoaDon.SoLuong = 1;

        hoaDon.ChiTietHoaDons.Add(chiTietHoaDon);
    }
    else
    {
        chiTietHoaDon.SoLuong++;
    }

    hoaDon.TongTien = hoaDon.ChiTietHoaDons
        .Sum(x => x.SoLuong * x.MovieObj.Price);

    HttpContext.Session.Set<HoaDon>("HoaDon", hoaDon);

    return View(hoaDon);
}

        // Xem giỏ hàng
public ActionResult Cart()
{
    var hoaDon = HttpContext.Session
        .Get<HoaDon>("HoaDon");

    return View("AddToCart", hoaDon);
}

// Xóa sản phẩm khỏi giỏ hàng
public ActionResult RemoveFromCart(int maMovies)
{
    var hoaDon = HttpContext.Session
        .Get<HoaDon>("HoaDon");

    var chiTietHoaDon = hoaDon.ChiTietHoaDons
        .FirstOrDefault(x => x.MaMovie == maMovies);

    if (chiTietHoaDon != null)
    {
        hoaDon.ChiTietHoaDons.Remove(chiTietHoaDon);
    }

    hoaDon.TongTien = hoaDon.ChiTietHoaDons
        .Sum(x => x.SoLuong * x.MovieObj.Price);

    HttpContext.Session.Set<HoaDon>("HoaDon", hoaDon);

    return RedirectToAction(nameof(Cart));
}

// Cập nhật số lượng
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult UpdateCart(int maMovies, int soLuong)
{
    var hoaDon = HttpContext.Session
        .Get<HoaDon>("HoaDon");

    var chiTietHoaDon = hoaDon.ChiTietHoaDons
        .FirstOrDefault(x => x.MaMovie == maMovies);

    if (chiTietHoaDon != null &&
        soLuong >= 1 && soLuong <= 99)
    {
        chiTietHoaDon.SoLuong = soLuong;
    }

    hoaDon.TongTien = hoaDon.ChiTietHoaDons
        .Sum(x => x.SoLuong * x.MovieObj.Price);

    HttpContext.Session.Set<HoaDon>("HoaDon", hoaDon);

    return RedirectToAction(nameof(Cart));
}

// GET: Movies/Checkout
public ActionResult Checkout()
{
    return View(new ShippingDetail());
}

// POST: Movies/Checkout
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Checkout(ShippingDetail detail)
{
    var hoaDon = HttpContext.Session
        .Get<HoaDon>("HoaDon");

    if (hoaDon.ChiTietHoaDons.Count == 0)
    {
        ModelState.AddModelError(
            "", "Giỏ hàng của bạn đang trống!");
    }

    if (ModelState.IsValid)
    {
        // Lưu đơn hàng vào SQL Server
        var order = new HoaDon
        {
            NgayLap = DateTime.Now,
            TongTien = hoaDon.TongTien
        };

        foreach (var ct in hoaDon.ChiTietHoaDons)
        {
            order.ChiTietHoaDons.Add(new ChiTietHoaDon
            {
                MaMovie = ct.MaMovie,
                SoLuong = ct.SoLuong
            });
        }

        detail.ID = 0;
        detail.ReleaseDate = DateTime.Today.AddDays(1);

        _context.HoaDons.Add(order);
        _context.ShippingDetails.Add(detail);

        await _context.SaveChangesAsync();

        // Xóa giỏ hàng sau khi đặt hàng thành công
        HttpContext.Session.Remove("HoaDon");

        // Soạn nội dung email xác nhận
        Func<string, string> enc =
            System.Net.WebUtility.HtmlEncode;

        StringBuilder body = new StringBuilder()
            .AppendLine("<h2>CINEHUB. - Movie Store</h2>")
            .AppendLine("<p>Cảm ơn bạn đã đặt hàng!</p>")
            .AppendLine($"<p>Mã đơn hàng: {order.MaHoaDon}</p>")
            .AppendLine("<hr/>")
            .AppendLine("<h3>Chi tiết đơn hàng</h3>")
            .AppendLine("<ul>");

        foreach (var ct in hoaDon.ChiTietHoaDons)
        {
            var subtotal = ct.MovieObj.Price * ct.SoLuong;

            body.AppendLine(
                $"<li>{ct.SoLuong} x {enc(ct.MovieObj.Title)}" +
                $" - {subtotal:N0} VNĐ</li>");
        }

        body.AppendLine("</ul>")
            .AppendLine(
                $"<p><b>Tổng tiền: {hoaDon.TongTien:N0} VNĐ</b></p>")
            .AppendLine("<hr/>")
            .AppendLine("<h3>Thông tin giao hàng</h3>")
            .AppendLine($"<p>Họ tên: {enc(detail.Name)}</p>")
            .AppendLine($"<p>Địa chỉ: {enc(detail.Address)}</p>")
            .AppendLine($"<p>Số điện thoại: {enc(detail.Mobile)}</p>")
            .AppendLine("<p>Cảm ơn bạn đã lựa chọn CineHub!</p>");

        // Lấy cấu hình Gmail từ User Secrets
        var gmail = _config["Email:Address"];
        var appPassword = _config["Email:AppPassword"];

        bool emailSent = false;

        if (!string.IsNullOrWhiteSpace(gmail) &&
            !string.IsNullOrWhiteSpace(appPassword))
        {
            emailSent = await EmailServiceNew.SendMailGoogleSmtp(
                gmail,
                detail.Email,
                "CineHub - Xác nhận đơn hàng",
                body.ToString(),
                gmail,
                appPassword);
        }

        ViewBag.OrderId = order.MaHoaDon;
        ViewBag.EmailSent = emailSent;

        return View("CheckoutCompleted");
    }

    return View(detail);
}

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
