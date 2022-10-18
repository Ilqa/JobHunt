using AutoMapper;

using JobHunt.Database.Entities;
using JobHunt.DTO;
using JobHunt.DTO.Identity;

namespace JobHunt.Mappings
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyDto, Company>().ReverseMap();
        }
    }
}