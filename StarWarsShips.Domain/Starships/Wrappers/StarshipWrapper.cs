using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsShips.Domain.Starships.Wrappers
{
    public class StarshipWrapper
    {
        [JsonProperty("count")]
        public long Total { get; set; }

        [JsonProperty("next")]
        public string NextUrl { get; set; }

        [JsonProperty("previous")]
        public string PreviousUrl { get; set; }

        [JsonProperty("results")]
        public List<StarshipDetailsWrapper> StarshipDetails { get; set; }
    }
}