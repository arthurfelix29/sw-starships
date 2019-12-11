using Newtonsoft.Json;

namespace StarWarsShips.Domain.Starships.Wrappers
{
    public class StarshipDetailsWrapper
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("MGLT")]
        public string MgltDistance { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }
    }
}