using Microsoft.AspNetCore.Mvc;

namespace Cted.CatalogoCursos.Apis.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
