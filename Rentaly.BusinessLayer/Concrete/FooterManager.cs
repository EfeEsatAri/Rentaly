using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.FooterDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;
        private readonly IMapper _mapper;

        public FooterManager(IFooterDal footerDal, IMapper mapper)
        {
            _footerDal = footerDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _footerDal.DeleteAsync(id);
        }

        public async Task<GetByIdFooterDto> TGetByIdAsync(int id)
        {
            var value = await _footerDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdFooterDto>(value);
        }

        public async Task<List<ResultFooterDto>> TGetListAsync()
        {
            var value = await _footerDal.GetListAsync();
            return _mapper.Map<List<ResultFooterDto>>(value);
        }

        public async Task TInsertAsync(CreateFooterDto dto)
        {
            var value = _mapper.Map<Footer>(dto);
            await _footerDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateFooterDto dto)
        {
            var value = _mapper.Map<Footer>(dto);
            await _footerDal.UpdateAsync(value);
        }
    }
}
