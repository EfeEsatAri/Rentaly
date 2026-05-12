using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DtoLayer.CommentDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public async Task TDeleteAsync(int id)
        {
            await _commentDal.DeleteAsync(id);
        }

        public async Task<GetByIdCommentDto> TGetByIdAsync(int id)
        {
            var value = await _commentDal.GetByIdAsync(id);
            return _mapper.Map<GetByIdCommentDto>(value);
        }

        public async Task<List<ResultCommentDto>> TGetListAsync()
        {
            var value = await _commentDal.GetListAsync();
            return _mapper.Map<List<ResultCommentDto>>(value);
        }

        public async Task TInsertAsync(CreateCommentDto dto)
        {
            var value = _mapper.Map<Comment>(dto);
            await _commentDal.InsertAsync(value);
        }
        public async Task TUpdateAsync(UpdateCommentDto dto)
        {
            var value = _mapper.Map<Comment>(dto);
            await _commentDal.UpdateAsync(value);
        }
    }
}
