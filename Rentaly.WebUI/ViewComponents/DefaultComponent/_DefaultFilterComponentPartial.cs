using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.DefaultComponent
{
    public class _DefaultFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                return View();
        }
    }
}
