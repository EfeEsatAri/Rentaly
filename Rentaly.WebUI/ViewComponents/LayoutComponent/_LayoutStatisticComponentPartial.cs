using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutStatisticComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
