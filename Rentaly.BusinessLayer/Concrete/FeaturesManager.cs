using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.FeaturesDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class FeaturesManager : IFeaturesService
    {
        private readonly IFeaturesDal _featuresDal;
        private readonly IMapper _mapper;

        public FeaturesManager(IFeaturesDal featuresDal, IMapper mapper)
        {
            _featuresDal = featuresDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _featuresDal.DeleteAsync(id);
        }

        public async Task<GetByIdFeaturesDto> TGetByIdAsync(int id)
        {
            var value = await _featuresDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdFeaturesDto>(value);
        }

        public async Task<List<ResultFeaturesDto>> TGetListAsync()
        {
            var value = await _featuresDal.GetListAsync();
            return _mapper.Map<List<ResultFeaturesDto>>(value);
        }

        public async Task TInsertAsync(CreateFeaturesDto dto)
        {
            var value = _mapper.Map<Features>(dto);
            await _featuresDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateFeaturesDto dto)
        {
            var value = _mapper.Map<Features>(dto);
            await _featuresDal.UpdateAsync(value);
        }
    }
}
