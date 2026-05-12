using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.QuestionsDtos;
using Rentaly.DtoLayer.StepDtos;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class StepController : Controller
    {
        private readonly IStepService _stepService;
        private readonly IMapper _mapper;
        public StepController(IStepService stepService, IMapper mapper)
        {
            _stepService = stepService;
            _mapper = mapper;
        }

        public async Task<IActionResult> StepList()
        {
            var values = await _stepService.TGetListAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteStep(int id)
        {
            await _stepService.TDeleteAsync(id);
            return RedirectToAction("StepList");
        }
        public IActionResult CreateStep()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStep(CreateStepDto dto)
        {
            await _stepService.TInsertAsync(dto);
            return RedirectToAction("StepList");
        }
        public async Task<IActionResult> UpdateStep(int id)
        {
            var values = await _stepService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateStepDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStep(UpdateStepDto dto)
        {
            await _stepService.TUpdateAsync(dto);
            return RedirectToAction("StepList");
        }
    }
}
