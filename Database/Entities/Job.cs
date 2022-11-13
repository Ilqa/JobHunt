using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Database.Entities
{
    public class Job : IAuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string City { get; set; }

        public int ViewCount { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public List<JobSkill> RequiredSKills { get; set; }

        [ForeignKey("PostedById")]
        public virtual User PostedBy { get; set; }
        public int PostedById { get; set; }

        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }

        public bool IsHidden { get; set; }

    }
}
