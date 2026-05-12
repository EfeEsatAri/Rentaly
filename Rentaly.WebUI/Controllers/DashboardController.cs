using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;

namespace Rentaly.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RentalyContext _context;

        public DashboardController(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalCars = await _context.Cars.CountAsync();
            ViewBag.AvailableCars = await _context.Cars.CountAsync(x => x.IsAvailable);
            ViewBag.TotalReservations = await _context.Reservations.CountAsync();
            ViewBag.PendingReservations = await _context.Reservations.CountAsync(x => x.Status == "Beklemede");
            ViewBag.TotalBrands = await _context.Brands.CountAsync();
            ViewBag.TotalBranches = await _context.Branches.CountAsync();
            var recentReservations = await _context.Reservations
                .OrderByDescending(x => x.ReservationId)
                .Take(5)
                .ToListAsync();

            return View(recentReservations);
        }
    }
}
