using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Database.Entities
{
    public class Job : IAuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int ViewCount { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //[ForeignKey("PostedById")]
        //public virtual User PostedBy { get; set; }
        //public int PostedById { get; set; }
    }
}
