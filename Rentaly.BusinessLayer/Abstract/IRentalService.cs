using Rentaly.DtoLayer.RentalDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IRentalService
    {
        Task<List<ResultRentalDto>> TGetListAsync();
        Task<GetByIdRentalDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateRentalDto dto);
        Task TUpdateAsync(UpdateRentalDto dto);
        Task TDeleteAsync(int id);
    }
}
