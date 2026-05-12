using Rentaly.DtoLayer.StepDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IStepService
    {
        Task<List<ResultStepDto>> TGetListAsync();
        Task<GetByIdStepDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateStepDto dto);
        Task TUpdateAsync(UpdateStepDto dto);
        Task TDeleteAsync(int id);
    }
}
