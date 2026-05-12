using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.FooterDtos;
using Rentaly.DtoLayer.QuestionsDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionsService _questionsService;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionsService questionsService, IMapper mapper)
        {
            _questionsService = questionsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> QuestionsList()
        {
            var value = await _questionsService.TGetListAsync();
            return View(value);
        }
        public async Task<IActionResult> DeleteQuestions(int id)
        {
            await _questionsService.TDeleteAsync(id);
            return RedirectToAction("QuestionsList");
        }
        public IActionResult CreateQuestions()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestions(CreateQuestionsDto dto)
        {
            await _questionsService.TInsertAsync(dto);
            return RedirectToAction("QuestionsList");
        }
        public async Task<IActionResult> UpdateQuestions(int id)
        {
            var values = await _questionsService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateQuestionsDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestions(UpdateQuestionsDto dto)
        {
            await _questionsService.TUpdateAsync(dto);
            return RedirectToAction("QuestionsList");
        }
    }
}
