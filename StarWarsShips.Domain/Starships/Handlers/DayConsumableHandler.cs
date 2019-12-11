using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class DayConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" day"))
            {
                return await Task.FromResult(24);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}