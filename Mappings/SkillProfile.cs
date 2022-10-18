using AutoMapper;

using JobHunt.Database.Entities;
using JobHunt.DTO;
using JobHunt.DTO.Identity;

namespace JobHunt.Mappings
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<SkillDto, Skill>().ReverseMap();
        }
    }
}