using AutoMapper;
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
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostModel>> List()
        {
            var res = await this.unitOfWork.PostRepository.GetAllAsync();
            return this.mapper.Map<List<PostModel>>(res);
        }

        public async Task<PostModel> Update(PostModel model)
        {
            throw new NotImplementedException();
        }
    }
}
