using System.Text.Json.Serialization;

namespace JobHunt.Database.Entities
{
    public class JobSkill
    {

        public int JobId { get; set; }
        public int SkillId { get; set; }

        [JsonIgnore]
        public Job Job { get; set; }

        [JsonIgnore]
        public Skill Skill { get; set; }
    }
}
