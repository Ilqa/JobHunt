using System;

namespace JobHunt.Database.Entities
{
    public class Company : IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
