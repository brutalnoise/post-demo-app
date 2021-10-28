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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PostModel> Add(PostModel model)
        {
            var entity = this.mapper.Map<Post>(model);

            var id = await this.unitOfWork.PostRepository.AddAsync(entity);

            model.Id = id;

            return model;
        }

        public async Task Delete(int id)
        {
            await this.unitOfWork.PostRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PostModel>> List()
        {
            var res = await this.unitOfWork.PostRepository.GetAllAsync();
            return this.mapper.Map<List<PostModel>>(res);
        }

        public async Task<PostModel> Update(PostModel model)
        {
            var entity = this.mapper.Map<Post>(model);
            await this.unitOfWork.PostRepository.UpdateAsync(entity);

            return model;
        }
    }
}
