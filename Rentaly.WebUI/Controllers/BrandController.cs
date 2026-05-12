using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.ValidationRules;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.EntityLayer.Entities;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto brand)
        {
            //var validator = new BrandValidator();
            //var result = validator.Validate(brand);

            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

            //    return View(brand);
            //}

            await _brandService.TInsertAsync(brand);
            return RedirectToAction("BrandList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var values = await _brandService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateBrandDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto brand)
        {
            await _brandService.TUpdateAsync(brand);
            return RedirectToAction("BrandList");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.TDeleteAsync(id);
            return RedirectToAction("BrandList");
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var value = await _brandService.TGetListAsync();
            return View(value);
        }
    }
}
