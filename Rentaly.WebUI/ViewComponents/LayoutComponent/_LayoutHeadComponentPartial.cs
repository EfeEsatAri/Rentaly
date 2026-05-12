using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
