using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DataAccessLayer.Migrations;
using Rentaly.DtoLayer.CarModelDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CarModelManager : ICarModelService
    {
        private readonly ICarModelDal _carModelDal;
        private readonly IMapper _mapper;

        public CarModelManager(ICarModelDal carModelDal, IMapper mapper)
        {
            _carModelDal = carModelDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _carModelDal.DeleteAsync(id);
        }

        public async Task<GetByIdCarModelDto> TGetByIdAsync(int id)
        {
            var value = await _carModelDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdCarModelDto>(value);
        }

        public async Task<List<ResultCarModelDto>> TGetListAsync()
        {
            var value = await _carModelDal.GetListAsync();
            return _mapper.Map<List<ResultCarModelDto>>(value);
        }

        public async Task TInsertAsync(CreateCarModelDto dto)
        {
            var value = _mapper.Map<CarModel>(dto);
            await _carModelDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateCarModelDto dto)
        {
            var value = _mapper.Map<CarModel>(dto);
            await _carModelDal.UpdateAsync(value);
        }
    }
}
