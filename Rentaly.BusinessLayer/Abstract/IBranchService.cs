using Rentaly.DtoLayer.BranchDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> TGetListAsync();
        Task<GetByIdBranchDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateBranchDto dto);
        Task TUpdateAsync(UpdateBranchDto dto);
        Task TDeleteAsync(int id);
    }
}
