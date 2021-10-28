using AutoMapper;
using PostDemoApp.Entities;
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
            var entity = this.mapper.Map<Comment>(model);
            
            var id = await this.unitOfWork.CommentRepository.AddAsync(entity);

            model.Id = id;

            return model;
        }

        public async Task Delete(int id)
        {
            await this.unitOfWork.CommentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CommentModel>> List()
        {
            var res = await this.unitOfWork.CommentRepository.GetAllAsync();
            return this.mapper.Map<List<CommentModel>>(res);
        }

        public async Task<CommentModel> Update(CommentModel model)
        {
            var entity = this.mapper.Map<Comment>(model);
            await this.unitOfWork.CommentRepository.UpdateAsync(entity);

            return model;
        }
    }
}
