using PostDemoApp.Repositories;
using PostDemoApp.UnitOfWorks.Interfaces;
using System.Net.Http;

namespace PostDemoApp.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository userRepository;
        private CommentRepository commentRepository;
        private PostRepository postRepository;

        public UnitOfWork()
        {

        }

        public UserRepository UserRepository 
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new UserRepository();

                return this.userRepository;
            }
        }
        public CommentRepository CommentRepository 
        {
            get
            {
                if (this.commentRepository == null)
                    this.commentRepository = new CommentRepository();

                return this.commentRepository;
            }
        }
        public PostRepository PostRepository 
        {
            get
            {
                if (this.postRepository == null)
                    this.postRepository = new PostRepository();

                return this.postRepository;
            }
        }

        //todo implement UoW IoC and so on....
    }
}
