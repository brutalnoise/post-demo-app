using PostDemoApp.Entities.Base;

namespace PostDemoApp.Entities
{
    public class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public virtual Post Post {get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
