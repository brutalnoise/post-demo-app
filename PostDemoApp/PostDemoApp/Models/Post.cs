using PostDemoApp.Models.Base;

namespace PostDemoApp.Models
{
    public class PostModel : BaseModel
    {
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsFavourite { get; set; }
        public int CommentsCount { get; set; }
        public PostModel()
        {

        }
    }
}
