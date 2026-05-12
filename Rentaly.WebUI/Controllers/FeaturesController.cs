using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.CommentDtos;
using Rentaly.DtoLayer.FeaturesDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeaturesService _featuresService;
        private readonly IMapper _mapper;
        public FeaturesController(IFeaturesService featuresService, IMapper mapper)
        {
            _featuresService = featuresService;
            _mapper = mapper;
        }

        public async Task<IActionResult> FeaturesList()
        {
            var value = await _featuresService.TGetListAsync();
            return View(value);
        }
        public async Task<IActionResult> DeleteFeatures(int id)
        {
            await _featuresService.TDeleteAsync(id);
            return RedirectToAction("FeaturesList");
        }
        public IActionResult CreateFeatures()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatures(CreateFeaturesDto dto)
        {
            await _featuresService.TInsertAsync(dto);
            return RedirectToAction("FeaturesList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeatures(int id)
        {
            var values = await _featuresService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateFeaturesDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatures(UpdateFeaturesDto dto)
        {
            await _featuresService.TUpdateAsync(dto);
            return RedirectToAction("FeaturesList");
        }
    }
}
