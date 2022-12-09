using System.Collections.Generic;

namespace JobHunt.DTO
{
    public class JobSearchFilter
    {
        public List<int> CountryIds { get; set; }

        public List<int> StateIds { get; set; }

        public List<int> CityIds { get; set; }

        public List<string> Titles { get; set; }
    }
}
