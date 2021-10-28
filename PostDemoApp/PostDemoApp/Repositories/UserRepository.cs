using PostDemoApp.Constants;
using PostDemoApp.Entities;
using System.Net.Http;

namespace PostDemoApp.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(HttpClient httpClient): base(httpClient)
        {
            base.baseUrl = ApiEndpoints.UsersEndpoint;
        }
    }
}
