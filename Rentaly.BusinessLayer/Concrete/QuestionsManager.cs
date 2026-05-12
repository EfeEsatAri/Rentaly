using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.QuestionsDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class QuestionsManager : IQuestionsService
    {
        private readonly IQuestionsDal _questionsDal;
        private readonly IMapper _mapper;

        public QuestionsManager(IQuestionsDal questionsDal, IMapper mapper)
        {
            _questionsDal = questionsDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _questionsDal.DeleteAsync(id);
        }

        public async Task<GetByIdQuestionsDto> TGetByIdAsync(int id)
        {
            var value = await _questionsDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdQuestionsDto>(value);
        }

        public async Task<List<ResultQuestionsDto>> TGetListAsync()
        {
            var value = await _questionsDal.GetListAsync();
            return _mapper.Map<List<ResultQuestionsDto>>(value);
        }

        public async Task TInsertAsync(CreateQuestionsDto dto)
        {
            var value = _mapper.Map<Questions>(dto);
            await _questionsDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateQuestionsDto dto)
        {
            var value = _mapper.Map<Questions>(dto);
            await _questionsDal.UpdateAsync(value);
        }
    }
}
