using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutBrandComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _LayoutBrandComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _context.Brands.ToListAsync();
            return View(value);
        }
    }
}
