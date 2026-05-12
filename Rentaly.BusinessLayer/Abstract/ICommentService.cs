using Rentaly.DtoLayer.CommentDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Abstract
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> TGetListAsync();
        Task<GetByIdCommentDto> TGetByIdAsync(int id);
        Task TInsertAsync(CreateCommentDto dto);
        Task TUpdateAsync(UpdateCommentDto dto);
        Task TDeleteAsync(int id);
    }
}
