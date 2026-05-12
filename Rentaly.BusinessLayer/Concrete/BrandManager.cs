using AutoMapper;
using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.ValidationRules;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.BranchDtos;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _brandDal.DeleteAsync(id);
        }

        public async Task<GetByIdBrandDto> TGetByIdAsync(int id)
        {
            var value = await _brandDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdBrandDto>(value);
        }

        public async Task<List<ResultBrandDto>> TGetListAsync()
        {
            var value = await _brandDal.GetListAsync();
            return _mapper.Map<List<ResultBrandDto>>(value);
        }

        public async Task TInsertAsync(CreateBrandDto dto)
        {
            var value = _mapper.Map<Brand>(dto);
            await _brandDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateBrandDto dto)
        {
            var value = _mapper.Map<Brand>(dto);
            await _brandDal.UpdateAsync(value);
        }
    }
}
