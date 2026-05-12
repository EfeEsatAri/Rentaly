using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.ReservationDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;
        private readonly IMapper _mapper;

        public ReservationManager(IReservationDal reservationDal, IMapper mapper)
        {
            _reservationDal = reservationDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _reservationDal.DeleteAsync(id);
        }

        public async Task<GetByIdReservationDto> TGetByIdAsync(int id)
        {
            var value = await _reservationDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdReservationDto>(value);
        }

        public async Task<List<ResultReservationDto>> TGetListAsync()
        {
            var value = await _reservationDal.GetListAsync();
            return _mapper.Map<List<ResultReservationDto>>(value);
        }

        public async Task TInsertAsync(CreateReservationDto dto)
        {
            var value = _mapper.Map<Reservation>(dto);
            await _reservationDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateReservationDto dto)
        {
            var value = _mapper.Map<Reservation>(dto);
            await _reservationDal.UpdateAsync(value);
        }
    }
}
