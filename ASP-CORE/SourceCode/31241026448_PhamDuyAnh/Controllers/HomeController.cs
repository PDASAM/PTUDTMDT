using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _31241026448_PhamDuyAnh.Models;

namespace _31241026448_PhamDuyAnh.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
{
    return RedirectToAction("Index", "Movies");
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
