using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutStepComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _LayoutStepComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Steps.ToListAsync();
            return View(values);
        }
    }
}
