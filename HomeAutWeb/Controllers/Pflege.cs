using Microsoft.AspNetCore.Mvc;

namespace HomeAutWeb.Controllers;

public class Pflege : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}