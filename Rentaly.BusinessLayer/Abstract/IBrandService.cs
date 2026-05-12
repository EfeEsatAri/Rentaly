using Rentaly.DtoLayer.BrandDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> TGetListAsync();
        Task<GetByIdBrandDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateBrandDto dto);
        Task TUpdateAsync(UpdateBrandDto dto);
        Task TDeleteAsync(int id);
    }
}
