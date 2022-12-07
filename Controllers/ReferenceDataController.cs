using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using JobHunt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Controllers
{
   // [Authorize]
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

        [HttpGet("Countries")]
        public async Task<IActionResult> GetCountires(string searchText) => Ok(await _service.GetCountries(searchText));

        [HttpGet("States")]
        public async Task<IActionResult> GetStates(int countryId, string searchText) => Ok(await _service.GetStates(countryId, searchText));

        [HttpGet("Cities")]
        public async Task<IActionResult> GetCities(int countryId, int? stateId, string searchText) => Ok(await _service.GetCities(countryId, stateId, searchText));
    }
}
