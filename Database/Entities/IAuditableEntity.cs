using System;

namespace JobHunt.Database.Entities
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

    }
}
