using AutoMapper;
using PostDemoApp.Entities;
using PostDemoApp.Models;

namespace PostDemoApp.Extensions
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<GeoLocation, GeoLocationModel>()
                .ReverseMap();

            CreateMap<Address, AddressModel>()
                .ReverseMap();

            CreateMap<Company, CompanyModel>()
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<Post, PostModel>()
                .ForMember(src => src.CommentsCount, dst => dst.Ignore())
                .ReverseMap();

            CreateMap<Comment, CommentModel>()
                .ReverseMap();
        }
    }
}
