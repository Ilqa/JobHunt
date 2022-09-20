using MovieReviews.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviews.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int ViewCount { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

        //[ForeignKey("PostedById")]
        //public virtual User PostedBy { get; set; }
        //public int PostedById { get; set; }
    }
}
