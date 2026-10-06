using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Echo(string name, int? count)
    {
        if (count == null)
        {
            return BadRequest();
        }
        ViewBag.Count = count;
        ViewBag.Name = name;
        
        return View();
    }
}