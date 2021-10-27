using AutoMapper;
using PostDemoApp.Models;
using PostDemoApp.Services.Interfaces;
using PostDemoApp.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDemoApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CommentModel> Add(CommentModel model)
        {
            var res = await this.unitOfWork.CommentRepository.GetAllAsync();
            return this.mapper.Map<CommentModel>(res);
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentModel>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<CommentModel> Update(CommentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
