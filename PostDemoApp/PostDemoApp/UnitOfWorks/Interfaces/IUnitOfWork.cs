using PostDemoApp.Repositories;

namespace PostDemoApp.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
        CommentRepository CommentRepository { get; }
        PostRepository PostRepository { get; }
    }
}
