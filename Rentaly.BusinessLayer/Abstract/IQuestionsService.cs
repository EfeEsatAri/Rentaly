using Rentaly.DtoLayer.QuestionsDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface IQuestionsService
    {
        Task<List<ResultQuestionsDto>> TGetListAsync();
        Task<GetByIdQuestionsDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateQuestionsDto dto);
        Task TUpdateAsync(UpdateQuestionsDto dto);
        Task TDeleteAsync(int id);
    }
}
