using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DtoLayer.QuestionsDtos;
using Rentaly.DtoLayer.ReservationDtos;
using System.Threading.Tasks;

namespace Rentaly.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ReservationList()
        {
            var values = await _reservationService.TGetListAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.TDeleteAsync(id);
            return RedirectToAction("ReservationList");
        }
        public IActionResult CreateReservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto dto)
        {
            await _reservationService.TInsertAsync(dto);
            return RedirectToAction("ReservationList");
        }
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var values = await _reservationService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateReservationDto>(values);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto dto)
        {
            await _reservationService.TUpdateAsync(dto);
            return RedirectToAction("ReservationList");
        }
    }
}
