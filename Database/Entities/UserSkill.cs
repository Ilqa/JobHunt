using System.Text.Json.Serialization;

namespace JobHunt.Database.Entities
{
    public class UserSkill
    {
        public int ProfileId { get; set; }
        public int SkillId { get; set;}

        [JsonIgnore]
        public UserProfile Profile { get; set; }

        [JsonIgnore]
        public Skill Skill { get; set; }
    }
}
