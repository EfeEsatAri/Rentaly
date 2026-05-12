using Rentaly.DtoLayer.FooterDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IFooterService
    {
        Task<List<ResultFooterDto>> TGetListAsync();
        Task<GetByIdFooterDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateFooterDto dto);
        Task TUpdateAsync(UpdateFooterDto dto);
        Task TDeleteAsync(int id);
    }
}
