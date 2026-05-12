using Rentaly.DtoLayer.ReservationDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IReservationService
    {
        Task<List<ResultReservationDto>> TGetListAsync();
        Task<GetByIdReservationDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateReservationDto dto);
        Task TUpdateAsync(UpdateReservationDto dto);
        Task TDeleteAsync(int id);
    }
}
