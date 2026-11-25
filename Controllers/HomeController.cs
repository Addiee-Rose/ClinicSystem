using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClinicSystem.Models;

namespace ClinicSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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

#if DEBUG
    // TEMP UI PREVIEW - remove when real login exists.
    // Remembers which role you want to preview, using a cookie.
    public IActionResult PreviewRole(string? role)
    {
        var allowed = new[] { "Patient", "Doctor", "ClinicStaff" };

        if (role != null && allowed.Contains(role))
            Response.Cookies.Append("previewRole", role);
        else
            Response.Cookies.Delete("previewRole");

        return RedirectToAction("Index");
    }
#endif
}

