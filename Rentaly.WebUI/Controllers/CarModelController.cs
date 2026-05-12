using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.DtoLayer.CarModelDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;
        private readonly IMapper _mapper;

        public CarModelController(IMapper mapper, ICarModelService carModelService)
        {
            _mapper = mapper;
            _carModelService = carModelService;
        }

        public async Task<IActionResult> CarModelList()
        {
            var value =await _carModelService.TGetListAsync();
            return View(value);
        }

        public IActionResult CreateCarModel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarModel(CreateCarModelDto dto)
        {
            await _carModelService.TInsertAsync(dto);
            return RedirectToAction("CarModelList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCarModel (int id)
        {
            var value = await _carModelService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateCarModelDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCarModel(UpdateCarModelDto dto)
        {
            await _carModelService.TUpdateAsync(dto);
            return RedirectToAction("CarModelList");
        }
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            await _carModelService.TDeleteAsync(id);
            return RedirectToAction("CarModelList");
        }
    }
}
