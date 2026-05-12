using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutTypeComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
