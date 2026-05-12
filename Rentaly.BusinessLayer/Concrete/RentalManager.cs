using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DtoLayer.RentalDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _rentalDal.DeleteAsync(id);
        }

        public async Task<GetByIdRentalDto> TGetByIdAsync(int id)
        {
            var value = await _rentalDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdRentalDto>(value);
        }

        public async Task<List<ResultRentalDto>> TGetListAsync()
        {
            var value = await _rentalDal.GetListAsync();
            return _mapper.Map<List<ResultRentalDto>>(value);
        }

        public async Task TInsertAsync(CreateRentalDto dto)
        {
            var value = _mapper.Map<Rental>(dto);
            await _rentalDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateRentalDto dto)
        {
            var value = _mapper.Map<Rental>(dto);
            await _rentalDal.UpdateAsync(value);
        }
    }
}
