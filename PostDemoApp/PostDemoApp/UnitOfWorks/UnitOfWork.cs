using PostDemoApp.Repositories;
using PostDemoApp.UnitOfWorks.Interfaces;
using System.Net.Http;

namespace PostDemoApp.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private HttpClient httpClient;
        private UserRepository userRepository;
        private CommentRepository commentRepository;
        private PostRepository postRepository;

        public UnitOfWork(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public UserRepository UserRepository 
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new UserRepository(this.httpClient);

                return this.userRepository;
            }
        }
        public CommentRepository CommentRepository 
        {
            get
            {
                if (this.commentRepository == null)
                    this.commentRepository = new CommentRepository(this.httpClient);

                return this.commentRepository;
            }
        }
        public PostRepository PostRepository 
        {
            get
            {
                if (this.postRepository == null)
                    this.postRepository = new PostRepository(this.httpClient);

                return this.postRepository;
            }
        }

        //todo implement UoW IoC and so on....
    }
}
