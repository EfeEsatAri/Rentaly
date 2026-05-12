using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutVehicleComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _LayoutVehicleComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _context.Cars
                .Include(x => x.Brand) 
                .Where(x => x.IsActive == true) 
                //.OrderByDescending(x => x.CarId) 
                .Take(7) 
                .ToListAsync();

            return View(value);
        }
    }
}
