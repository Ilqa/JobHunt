using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Controllers
{
    [Route("api/ReferenceData")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly RoleManager<UserType> _roleManager;

        public ReferenceDataController(ISkillRepository skillRepository, ICompanyRepository companyRepositor, RoleManager<UserType> roleManager, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepositor;
            _mapper = mapper;
            _roleManager = roleManager;
        }


        [HttpGet("Skills")]
        public async Task<List<SkillDto>> GetAllSkills()
        {
            var skills = await _skillRepository.GetAllSkills();
            return _mapper.Map<List<SkillDto>>(skills);
        }

        [HttpGet("UserTypes")]
        public async Task<List<UserType>> GetAllUserTypes()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        [HttpPost("Skill")]
        public async Task AddSkill(SkillDto skill)
        {
            await _skillRepository.AddSkill(_mapper.Map<Skill>(skill));
        }


        [HttpGet("Comapnies")]
        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            return  _mapper.Map<List<CompanyDto>>(companies);
        }

        [HttpPost("Company")]
        public async Task AddCompany(CompanyDto company)
        {
            await _companyRepository.AddCompany(_mapper.Map<Company>(company));
        }
    }
}
