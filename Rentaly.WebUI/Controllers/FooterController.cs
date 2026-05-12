using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.FeaturesDtos;
using Rentaly.DtoLayer.FooterDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class FooterController : Controller
    {
        private readonly IFooterService _footerService;
        private readonly IMapper _maapper;
        public FooterController(IFooterService footerService, IMapper maapper)
        {
            _footerService = footerService;
            _maapper = maapper;
        }

        public async Task<IActionResult> FooterList()
        {
            var value = await _footerService.TGetListAsync();
            return View(value);
        }
        public async Task<IActionResult> DeleteFooter(int id)
        {
            await _footerService.TDeleteAsync(id);
            return RedirectToAction("FooterList");
        }
        public IActionResult CreateFooter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterDto dto)
        {
            await _footerService.TInsertAsync(dto);
            return RedirectToAction("FooterList");
        }
        public async Task<IActionResult> UpdateFooter(int id)
        {
            var values = await _footerService.TGetByIdAsync(id);
            var mappedValue = _maapper.Map<UpdateFooterDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFooter(UpdateFooterDto dto)
        {
            await _footerService.TUpdateAsync(dto);
            return RedirectToAction("FooterList");
        }
    }
}
