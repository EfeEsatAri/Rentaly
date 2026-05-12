using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.ViewComponents.DefaultComponent
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
