using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.DtoLayer.CommentDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CommentList()
        {
            var value =await _commentService.TGetListAsync();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.TDeleteAsync(id);
            return RedirectToAction("CommentList");
        }
        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto dto)
        {
            await _commentService.TInsertAsync(dto);
            return RedirectToAction("CommentList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var values = await _commentService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateCommentDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto)
        {
            await _commentService.TUpdateAsync(dto);
            return RedirectToAction("CommentList");
        }
    }
}
