using AutoMapper;

using JobHunt.Database.Entities;
using JobHunt.DTO;
using JobHunt.DTO.Identity;

namespace JobHunt.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<JobHunt.Database.Entities.UserProfile, UserProfileDto>().ReverseMap();
        }
    }
}