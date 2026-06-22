using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SunmedLodge.Models;

namespace SunmedLodge.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public IActionResult Index() => View();
    public IActionResult Rooms() => View();
    public IActionResult Gallery() => View();
    public IActionResult About() => View();
    public IActionResult Contact() => View();

    public IActionResult Menu()
    {
        var filePath = Path.Combine(_environment.ContentRootPath, "menu", "menu.pdf");

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        Response.Headers["Content-Disposition"] = "inline; filename=\"sunmed-lodge-menu.pdf\"";
        return PhysicalFile(filePath, "application/pdf", enableRangeProcessing: true);
    }

    [HttpGet]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true }
        );
        return LocalRedirect(returnUrl);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
