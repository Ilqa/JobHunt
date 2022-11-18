using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using JobHunt.Services;
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
      
        private readonly IReferenceDataService _service;


        public ReferenceDataController(IReferenceDataService service) => _service = service;

        [HttpGet("Skills")]
        public async Task<IActionResult> GetAllSkills() => Ok(await _service.GetAllSkills());

        [HttpGet("UserTypes")]
        public async Task<IActionResult> GetAllUserTypes() => Ok(await _service.GetAllUserTypes());

        [HttpPost("Skill")]
        public async Task<IActionResult> AddSkill(SkillDto skill) => Ok(await _service.AddSkill(skill));

        [HttpGet("Comapnies")]
        public async Task<IActionResult> GetAllCompanies() => Ok(await _service.GetAllCompanies());

        [HttpPost("Company")]
        public async Task<IActionResult> AddCompany(CompanyDto company) => Ok(await _service.AddCompany(company));
    }
}
