using Microsoft.AspNetCore.Mvc;

namespace Cted.CatalogoCursos.Controllers;

public class AvaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
