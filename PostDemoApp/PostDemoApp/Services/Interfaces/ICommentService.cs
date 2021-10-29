using PostDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostDemoApp.Services.Interfaces
{
    public interface ICommentService : IBaseServiceInterface<CommentModel>
    {
        Task<IEnumerable<CommentModel>> GetAllByPostId(int postId);
    }
}
