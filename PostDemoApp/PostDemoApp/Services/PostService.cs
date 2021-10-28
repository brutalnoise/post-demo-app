using AutoMapper;
using PostDemoApp.Entities;
using PostDemoApp.Models;
using PostDemoApp.Services.Interfaces;
using PostDemoApp.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostDemoApp.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICommentService commentService;
        private readonly IUserService userService;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService, ICommentService commentService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
            this.commentService = commentService;
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
            var models = this.mapper.Map<List<PostModel>>(res);
            await PopulatePostModels(models);
            return models;
        }

        public async Task<PostModel> Update(PostModel model)
        {
            var entity = this.mapper.Map<Post>(model);
            await this.unitOfWork.PostRepository.UpdateAsync(entity);

            return model;
        }

        public async Task<PostModel> GetById(int id)
        {
            var entity = await this.unitOfWork.PostRepository.GetByIdAsync(id);
            return this.mapper.Map<PostModel>(entity);
        }


        #region helpers
        private async Task PopulatePostModels(IEnumerable<PostModel> models)
        {
            var comments = await this.commentService.List();
            var users = await this.userService.List();

            foreach (var model in models)
            {
                model.User = users.FirstOrDefault(u => u.Id == model.UserId);
                model.CommentsCount = comments.Where(c => c.PostId == model.Id).Count();
            }
        }

        #endregion
    }
}
