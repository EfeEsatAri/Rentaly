using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.DefaultComponent
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
