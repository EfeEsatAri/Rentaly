using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DtoLayer.StepDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class StepManager : IStepService
    {
        private readonly IStepDal _stepDal;
        private readonly IMapper _mapper;

        public StepManager(IStepDal stepDal, IMapper mapper)
        {
            _stepDal = stepDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _stepDal.DeleteAsync(id);
        }

        public async Task<GetByIdStepDto> TGetByIdAsync(int id)
        {
            var value = await _stepDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdStepDto>(value);
        }

        public async Task<List<ResultStepDto>> TGetListAsync()
        {
            var value = await _stepDal.GetListAsync();
            return _mapper.Map<List<ResultStepDto>>(value);
        }

        public async Task TInsertAsync(CreateStepDto dto)
        {
            var value = _mapper.Map<Step>(dto);
            await _stepDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateStepDto dto)
        {
            var value = _mapper.Map<Step>(dto);
            await _stepDal.UpdateAsync(value);
        }
    }
}
