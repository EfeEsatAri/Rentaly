using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
