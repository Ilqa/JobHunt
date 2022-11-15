using AutoMapper;

using JobHunt.Database.Entities;
using JobHunt.DTO;
using JobHunt.DTO.Identity;

namespace JobHunt.Mappings
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobDto, Job>().ReverseMap();
            CreateMap<JobSkillDto, JobSkill>().ReverseMap();
        }
    }
}