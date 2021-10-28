using PostDemoApp.Models.Base;

namespace PostDemoApp.Models
{
    public class UserModel: BaseModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public CompanyModel Company { get; set; }

        public UserModel()
        {

        }
    }
}
