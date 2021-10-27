using AutoMapper;
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
            var res = await this.unitOfWork.UserRepository.GetAllAsync();
            return this.mapper.Map<UserModel>(res);
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
