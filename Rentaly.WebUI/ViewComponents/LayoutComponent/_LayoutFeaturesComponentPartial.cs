using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutFeaturesComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _LayoutFeaturesComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Features.ToListAsync();
            return View(values);
        }
    }
}
