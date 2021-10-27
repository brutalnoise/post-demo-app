using PostDemoApp.Entities.Base;

namespace PostDemoApp.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }

        public User()
        {

        }
    }
}
