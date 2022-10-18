using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Database.Entities
{
    public class UserProfile : IAuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [MaxLength(256)]
        public string Region { get; set; }
        [MaxLength(256)]
        public string AvailableRegions { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

        public string Address { get; set; }

        public string ResumeFileName { get; set; }

        public string VideoFileName{ get; set; }

        public byte[] ResumeFileData { get; set; }

        public byte[] VideoFileData { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string City { get; set; }

        public string ProfileHeadline { get; set; }

        public List<UserSkill> Skills { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

         public List<UserEducation> EducationDetails { get; set; }

         public List<UserExperience> JobHistory { get; set; }



    }
}
