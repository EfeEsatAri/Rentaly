using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.BranchDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.TGetListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBranch()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto branch)
        {
            await _branchService.TInsertAsync(branch);
            return RedirectToAction("BranchList");
        }
        public IActionResult UpdateBranch()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto dto)
        {
            await _branchService.TUpdateAsync(dto);
            return RedirectToAction("BranchList");
        }
        public async Task<IActionResult> DeleteBranch(int id)
        {
            await _branchService.TDeleteAsync(id);
            return RedirectToAction("BranchList");
        }
    }
}
