using System;

namespace JobHunt.DTO
{
    public class UserExperienceDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

       // public Company Company { get; set; }

        public int CompanyId { get; set; }

        public string Designation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool CurrentlyWorking { get; set; }

        public string Industry { get; set; }
    }
}
