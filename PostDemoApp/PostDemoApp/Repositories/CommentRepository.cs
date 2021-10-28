using PostDemoApp.Constants;
using PostDemoApp.Entities;
using System.Net.Http;

namespace PostDemoApp.Repositories
{
    public class CommentRepository : BaseRepository<Post>
    {
        public CommentRepository(HttpClient httpClient): base(httpClient)
        {
            base.baseUrl = ApiEndpoints.CommentsEndpoint;
        }
    }
}
