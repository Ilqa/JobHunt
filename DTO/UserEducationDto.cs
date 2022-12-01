using System;

namespace JobHunt.DTO
{
    public class UserEducationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string InstitutionName { get; set; }

        public string DegreeTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // public bool CurrentlyEnrolled { get; set; }

        public string Grade { get; set; }

        public string FieldOfStudy { get; set; }
    }
    }
