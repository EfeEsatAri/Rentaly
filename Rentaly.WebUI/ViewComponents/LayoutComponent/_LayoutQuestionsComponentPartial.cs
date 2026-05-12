using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Concrete;
using System.Threading.Tasks;

namespace Rentaly.WebUI.ViewComponents.LayoutComponent
{
    public class _LayoutQuestionsComponentPartial:ViewComponent
    {
        private readonly RentalyContext _context;

        public _LayoutQuestionsComponentPartial(RentalyContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.questions.ToListAsync();
            return View(values);
        }
    }
}
