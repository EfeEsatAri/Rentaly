using Rentaly.DtoLayer.FeaturesDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IFeaturesService
    {
        Task<List<ResultFeaturesDto>> TGetListAsync();
        Task<GetByIdFeaturesDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateFeaturesDto dto);
        Task TUpdateAsync(UpdateFeaturesDto dto);
        Task TDeleteAsync(int id);
    }
}
