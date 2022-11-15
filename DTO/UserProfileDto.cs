using JobHunt.Database.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobHunt.DTO
{
    public class UserProfileDto
    {
        [MaxLength(256)]
        public string Region { get; set; }
        [MaxLength(256)]
        public string AvailableRegions { get; set; }

        public int? CompanyId { get; set; }

        public string Address { get; set; }

        public string ResumeFileName { get; set; }

       public string VideoFileName { get; set; }

        //[ForeignKey("UserId")]
        //public User User { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string City { get; set; }

        public string ProfileHeadline { get; set; }
        public string PhoneNumber { get; set; }
        public string Skills { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }

        public List<UserEducationDto> EducationDetails { get; set; }

        public List<UserExperienceDto> JobHistory { get; set; }
        public string Email { get; internal set; }
    }
}
