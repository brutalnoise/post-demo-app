using PostDemoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostDemoApp.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<IEnumerable<Comment>> GetComments();
        Task<IEnumerable<User>> GetUsers();

        Task MigrateData();
    }
}
