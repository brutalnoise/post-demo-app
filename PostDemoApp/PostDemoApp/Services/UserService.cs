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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserModel> Add(UserModel model)
        {
            var entity = this.mapper.Map<User>(model);

            var id = await this.unitOfWork.UserRepository.AddAsync(entity);

            model.Id = id;

            return model;
        }

        public async Task Delete(int id)
        {
            await this.unitOfWork.UserRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserModel>> List()
        {
            var res = await this.unitOfWork.UserRepository.GetAllAsync();
            return this.mapper.Map<List<UserModel>>(res);
        }

        public async Task<UserModel> Update(UserModel model)
        {
            var entity = this.mapper.Map<User>(model);
            await this.unitOfWork.UserRepository.UpdateAsync(entity);

            return model;
        }

        public async Task<UserModel> GetById(int id)
        {
            var entity = await this.unitOfWork.UserRepository.GetByIdAsync(id);
            return this.mapper.Map<UserModel>(entity);
        }
    }
}
