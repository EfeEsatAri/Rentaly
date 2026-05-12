using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;
        private readonly IBranchService _branchService;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly RentalyContext _context;

        public CarController(ICarService carService, ICategoryService categoryService, IBranchService branchService, IBrandService brandService, ICarModelService carModelService, RentalyContext context)
        {
            _carService = carService;
            _categoryService = categoryService;
            _branchService = branchService;
            _brandService = brandService;
            _carModelService = carModelService;
            _context = context;
        }

        public async Task<IActionResult> CarList()
        {
            var values = await _carService.TGetAllCarswithCategoryAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
             ViewBag.Categories=new SelectList(await _categoryService.TGetListAsync(), "CategoryId", "CategoryName");
            ViewBag.Branches = new SelectList(await _branchService.TGetListAsync(), "BranchId", "BranchName");
            ViewBag.Brands = new SelectList(await _brandService.TGetListAsync(), "BrandId", "BrandName");
            ViewBag.CarModel = new SelectList(await _carModelService.TGetListAsync(), "CarModelId", "ModelName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            await _carService.TInsertAsync(car);
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryService.TGetListAsync(), "CategoryId", "CategoryName");
            ViewBag.Branches = new SelectList(await _branchService.TGetListAsync(), "BranchId", "BranchName");
            ViewBag.Brands = new SelectList(await _brandService.TGetListAsync(), "BrandId", "BrandName");
            ViewBag.CarModel = new SelectList(await _carModelService.TGetListAsync(), "CarModelId", "ModelName");
            var car = await _carService.TGetByIdAsync(id);
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            Console.WriteLine($"CarId: {car.CarId}");
            Console.WriteLine($"BrandId: {car.BrandId}");
            await _carService.TUpdateAsync(car);
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (id != 0)
            {
                await _carService.TDeleteAsync(id);
            }
            return RedirectToAction("CarList");
        }
    }
}


