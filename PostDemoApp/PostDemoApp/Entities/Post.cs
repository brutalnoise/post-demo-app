using PostDemoApp.Entities.Base;

namespace PostDemoApp.Entities
{
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post()
        {

        }
    }
}
