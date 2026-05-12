using Rentaly.DtoLayer.CarModelDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface ICarModelService
    {
        Task<List<ResultCarModelDto>> TGetListAsync();
        Task<GetByIdCarModelDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateCarModelDto dto);
        Task TUpdateAsync(UpdateCarModelDto dto);
        Task TDeleteAsync(int id);
    }
}
