using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AkilliTakipSistemi.Models;

namespace AkilliTakipSistemi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
