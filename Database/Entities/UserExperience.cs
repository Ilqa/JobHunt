using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Database.Entities
{
    public class UserExperience
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public string Designation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
