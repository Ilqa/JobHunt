using AutoMapper;
using GenPsych.Application.Responses.Identity;
using JobHunt.Database.Entities;

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