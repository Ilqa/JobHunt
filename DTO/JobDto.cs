using JobHunt.Database.Entities;
using System.Collections.Generic;

namespace JobHunt.DTO
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        public int ViewCount { get; set; }

        
        public int? CompanyId { get; set; }
       
        public List<JobSkillDto> RequiredSKills { get; set; }

        
        public int PostedById { get; set; }

        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }

        public bool IsHidden { get; set; }

    }

    public class JobSkillDto
    {
        public int JobId { get; set; }
        public int SkillId { get; set; }
    }
}
