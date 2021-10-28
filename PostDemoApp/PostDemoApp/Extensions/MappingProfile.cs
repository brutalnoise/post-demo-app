using AutoMapper;
using PostDemoApp.Entities;
using PostDemoApp.Models;

namespace PostDemoApp.Extensions
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<GeoLocation, GeoLocationModel>();
            CreateMap<Address, AddressModel>();
            CreateMap<Company, CompanyModel>();
            CreateMap<User, UserModel>();
            CreateMap<Post, PostModel>();
            CreateMap<Comment, CommentModel>();
        }
    }
}
