using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.DefaultComponent
{
    public class _DefaultCarListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
