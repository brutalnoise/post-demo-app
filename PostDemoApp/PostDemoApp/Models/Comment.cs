using PostDemoApp.Models.Base;

namespace PostDemoApp.Models
{
    public class CommentModel : BaseModel
    {
        public int PostId { get; set; }
        public virtual PostModel Post {get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
