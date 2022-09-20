using AutoMapper;
using GenPsych.Application.Responses.Identity;
using MovieReviews.Entities;

namespace GenPsych.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            //CreateMap<, User>().ReverseMap();
        }
    }
}