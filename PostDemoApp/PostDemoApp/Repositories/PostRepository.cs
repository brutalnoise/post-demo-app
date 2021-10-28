using PostDemoApp.Constants;
using PostDemoApp.Entities;
using System.Net.Http;

namespace PostDemoApp.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(HttpClient httpClient): base(httpClient)
        {
            base.baseUrl = ApiEndpoints.PostsEndpoint;
        }
    }
}
