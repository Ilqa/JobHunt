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
            CreateMap<JobHunt.Database.Entities.UserProfile, UserProfileDto>()
                .ForMember(dist => dist.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dist => dist.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dist => dist.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dist => dist.Email, opt => opt.MapFrom(src => src.User.Email));


            CreateMap<UserProfileDto, JobHunt.Database.Entities.UserProfile>()
                .ForPath(dist => dist.User.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dist => dist.User.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForPath(dist => dist.User.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForPath(dist => dist.User.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserEducation, UserEducationDto>().ReverseMap();
            CreateMap<UserExperience, UserExperienceDto>().ReverseMap();
            CreateMap<UserTypeDto, UserType>().ReverseMap();
        }
    }
}