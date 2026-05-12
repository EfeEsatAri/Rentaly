using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.Controllers
{
    public class _404PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
