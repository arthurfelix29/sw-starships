using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class WeekConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" week"))
            {
                return await Task.FromResult(168);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}